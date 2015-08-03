﻿using System.Threading.Tasks;
using Wizard.Api.Models;

namespace Wizard.Api.Services.Interfaces
{
    public interface IStableService
    {
        Task Save(StableContract stable);
        Task<string> Get(string email);
    }
}