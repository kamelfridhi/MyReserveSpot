using System;
using RepositoryPatternWithUOW.Core.Enum;

namespace RespositoryPatternWithUOW.Api.Model.Reservation
{
    public class ReservationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime FirstReservationDate { get; set; }
        public DateTime LastReservationDate { get; set; }
        public string email { get; set; }
        public CheckRole UserPermission { get; set; }
        public AgentAction AgentAction { get; set; }    
    }
}
