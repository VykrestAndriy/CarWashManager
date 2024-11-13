using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.Contracts;

public interface IWashService
{
    Task<IReadOnlyList<WashDto>> Get();
    Task<WashDto> Get(string washId);
    Task Add(WashDto wash);
    Task Update(WashDto wash);
    Task Remove(string washId);
}