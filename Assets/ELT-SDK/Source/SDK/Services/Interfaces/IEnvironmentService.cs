﻿using System.Collections;
using ELT_SDK.Source.Data;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IEnvironmentService
   {
      EnvironmentData EnvironmentData { get; }
      IEnumerator LoadEnvironmentData();
   }
}