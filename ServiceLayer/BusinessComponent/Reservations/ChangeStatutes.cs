using EntityLayer.MemberShip;
using EntityLayer.Reservation;
using RepositoryPatternWithUOW.Core.Enum;

namespace BusinessComponent.Reservations
{
    public class ChangeStatutes
    {

        public void ApplyChange(Func<string, Guid> getStatuId,EnumStatus currentStatu ,ref Reservation reservation, AgentAction? agentAction=null, CheckRole? userPermission=null)
        {            
            switch (currentStatu)
            {
                case EnumStatus.Initial:
                    PassReservationFromIntialToNextMode(reservation, userPermission, getStatuId);
                    break;
               case EnumStatus.New:
                    PassReservationFromNewToInProgress(reservation, userPermission, getStatuId);
                    break;
                case EnumStatus.InProgress:
                    PassReservationFromInProgressToNextMode(reservation,agentAction, userPermission, getStatuId);
                    break;
                case EnumStatus.Suspended:
                    PassReservationFromSuspendedToInprogress(reservation, getStatuId);
                    break;
                case EnumStatus.Closed:
                    PassReservationFromClosedToInprogress(reservation, getStatuId);
                    break;
            }

        }
        
        public void PassReservationFromIntialToNextMode(Reservation reservation,CheckRole? role, Func<string, Guid> getStatuId) 
        {
            
            if (role== CheckRole.User) 
            {
                var statuId = getStatuId(EnumStatus.New.ToString());
                PassReservationFromIntialToNew(reservation,statuId);
            }
            else
            {
                var statuId = getStatuId(EnumStatus.InProgress.ToString());
                PassReservationFromIntialToInProgress(reservation, statuId);
            }
        }
        public void PassReservationFromIntialToNew(Reservation reservation,Guid statuId) 
        {
            reservation.StatuId = statuId;
        }
        public void PassReservationFromIntialToInProgress(Reservation reservation, Guid statuId)
        {
            reservation.StatuId = statuId;
        }

        public void PassReservationFromNewToInProgress(Reservation reservation, CheckRole? role, Func<string, Guid> getStatuId)
        {
            if (role == CheckRole.Admin || role == CheckRole.Agent)
            {
                var statuId = getStatuId(EnumStatus.InProgress.ToString());
                reservation.StatuId = statuId;

            }

        }
        public void PassReservationFromInProgressToNextMode(Reservation reservation, AgentAction? agentAction,CheckRole? role, Func<string, Guid> getStatuId)
        {
            var hasPermission = (role == CheckRole.Agent || role == CheckRole.Admin);
            if (agentAction== AgentAction.Closed && hasPermission)
            {
                var statuId = getStatuId(EnumStatus.Closed.ToString());
                PassReservationFromInProgressToClosed(reservation, statuId);
            }
            else
            {
                var statuId = getStatuId(EnumStatus.Suspended.ToString());
                PassReservationFromInProgressToSuspended(reservation, statuId);
            }

        }

        public void PassReservationFromInProgressToClosed(Reservation reservation, Guid statuId)
        {
            reservation.StatuId = statuId;
        }
        public void PassReservationFromInProgressToSuspended(Reservation reservation, Guid statuId)
        {
            reservation.StatuId = statuId;
        }

        public void PassReservationFromSuspendedToInprogress(Reservation reservation, Func<string, Guid> getStatuId)
        {
            var statuId = getStatuId(EnumStatus.InProgress.ToString());
            reservation.StatuId = statuId;


        }

        public void PassReservationFromClosedToInprogress(Reservation reservation, Func<string, Guid> getStatuId)
        {
            var statuId = getStatuId(EnumStatus.InProgress.ToString());
            reservation.StatuId = statuId;
        }
    }
}
