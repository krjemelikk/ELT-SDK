using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using ELTSDK.Source;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
   [SerializeField] private Dropdown _interfacesDropdown;
   [SerializeField] private Dropdown _methodsDropDown;
   [SerializeField] private InputField _inputField;
   [SerializeField] private Button _button;

   private readonly Dictionary<string, object> _interfaces = new();
   private Dictionary<string, MethodInfo> _currentMethods = new();

   private void OnEnable()
   {
      Subscribes();
   }

   private void Start()
   {
      ELTSDKRoot.Instance.Initialize();
      FillInterfaceDictionary();
      FillInterfaceDropdown();
   }

   private void OnDisable()
   {
      UnSubscribes();
   }

   private void FillInterfaceDictionary()
   {
      var propertyInfos = ELTSDKRoot.Instance
         .GetType()
         .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

      foreach (var prop in propertyInfos)
         _interfaces[prop.Name] = prop.GetValue(ELTSDKRoot.Instance);
   }

   private void FillInterfaceDropdown()
   {
      _interfacesDropdown.ClearOptions();
      _interfacesDropdown.AddOptions(_interfaces.Keys.ToList());

      OnInterfaceChanged(0);
   }

   private void UpdateMethodsDropdown(List<string> methods)
   {
      _methodsDropDown.ClearOptions();
      _methodsDropDown.AddOptions(methods);

      OnMethodChanged(0);
   }

   private void OnInterfaceChanged(int index)
   {
      var interfaceName = _interfacesDropdown.options[index].text;
      var selectedInterface = _interfaces[interfaceName];

      var methodsOfInterface = selectedInterface.GetType()
         .GetMethods(BindingFlags.Instance | BindingFlags.Public)
         .Where(m => !m.IsSpecialName)
         .ToList();

      _currentMethods = methodsOfInterface.ToDictionary(x => x.Name, x => x);
      UpdateMethodsDropdown(methodsOfInterface.Select(x => x.Name).ToList());
   }

   private void OnMethodChanged(int index)
   {
      var methodName = _methodsDropDown.options[index].text;
      var method = _currentMethods[methodName];

      var paramNames = method.GetParameters()
         .Select(p => p.Name)
         .ToArray();

      _inputField.placeholder.GetComponent<Text>().text = string.Join(", ", paramNames);
   }

   private void InvokeSelectedMethod()
   {
      var interfaceName = _interfacesDropdown.options[_interfacesDropdown.value].text;
      var selectedInterface = _interfaces[interfaceName];

      var methodName = _methodsDropDown.options[_methodsDropDown.value].text;
      var selectedMethod = _currentMethods[methodName];


      var methodParameters = ParseParameters(_inputField.text, selectedMethod.GetParameters());

      if (selectedMethod.ReturnType == typeof(UniTask))
         _ = InvokeAsyncMethod(selectedMethod, selectedInterface, methodParameters);
      else
         selectedMethod.Invoke(selectedInterface, methodParameters);
   }

   private object[] ParseParameters(string input, ParameterInfo[] parameterInfos)
   {
      var rawInputs = string.IsNullOrWhiteSpace(input) ? null : input.Split(',');

      if (rawInputs == null && parameterInfos.Length == 1)
         return new object[] {null};

      if (rawInputs == null || rawInputs.Length != parameterInfos.Length)
         return null;

      var parsedParams = new object[parameterInfos.Length];

      for (int i = 0; i < parameterInfos.Length; i++)
      {
         var raw = rawInputs[i].Trim();
         var targetType = parameterInfos[i].ParameterType;

         try
         {
            parsedParams[i] = Convert.ChangeType(raw, targetType);
         }
         catch (Exception e)
         {
            Debug.LogWarning($"Error with ChangeType index {i + 1} in {targetType.Name}: {e.Message}");
            return null;
         }
      }

      return parsedParams;
   }

   private async UniTaskVoid InvokeAsyncMethod(MethodInfo method, object target, object[] parameters)
   {
      try
      {
         await (UniTask) method.Invoke(target, parameters);
      }
      catch (Exception ex)
      {
         Debug.LogError($"Error with UniTask method: {ex.Message}");
      }
   }


   private void Subscribes()
   {
      _interfacesDropdown.onValueChanged.AddListener(OnInterfaceChanged);
      _methodsDropDown.onValueChanged.AddListener(OnMethodChanged);
      _button.onClick.AddListener(InvokeSelectedMethod);
   }

   private void UnSubscribes()
   {
      _interfacesDropdown.onValueChanged.RemoveAllListeners();
      _methodsDropDown.onValueChanged.RemoveAllListeners();
      _button.onClick.RemoveAllListeners();
   }
}