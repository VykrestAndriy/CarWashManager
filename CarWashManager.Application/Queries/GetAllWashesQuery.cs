using MediatR;
using CarWashManager.Core.Dtos;

namespace CarWashManager.Application.Queries
{
    public class GetAllWashesQuery : IRequest<List<WashDto>>
    {
        public string? WashType { get; set; }  
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }   

        public GetAllWashesQuery(string? washType, DateTime? startDate, DateTime? endDate)
        {
            WashType = washType;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
