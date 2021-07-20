using System;

namespace TimeTrackerMt.DataRepository.Model
{
    public class UserMaster
    {

        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DOB { get; set; }
        //public int RoleID { get; set; }
        public string Gender { get; set; }
        public int MaritalStatusID { get; set; }
        public string Mobile { get; set; }
        public bool Status { get; set; }
        public bool Status1 { get; set; }
        public string RoleName { get; set; }
        public string StatusName { get; set; }
        public string Token { get; set; }
        public string authToken { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //just to get information
        public string registrationStatus { get; set; }
        public bool? CheckedIn { get; set; }
        public string TicketPrice { get; set; }
        public string EventId { get; set; }
        public bool IsManual { get; set; }

        public float longitude { get; set; }
        public float latitude { get; set; }

        public long RecordsTotal { get; set; }
        public long RecordsFiltered { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsVerified { get; set; }

        public object MobileData { get; set; }

        public bool IsGoogleUser { get; set; }
        public bool IsFacebookUser { get; set; }



    }
}