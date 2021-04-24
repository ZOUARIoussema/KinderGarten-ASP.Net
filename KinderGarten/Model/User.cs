using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum Role
    {
        ROLE_adminGarten, ROLE_admin, ROLE_parent, ROLE_visitor, ROLE_doctor, ROLE_futurParent, ROLE_agentCashier, ROLE_provider
    }

    public enum StateUser
    {
        active, blocked, waiting


    }



    public class User
    {

        [JsonProperty("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [JsonProperty("firstName")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [JsonProperty("lastName")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [JsonProperty("address")]
        [DataType(DataType.MultilineText)]
        public String Address { get; set; }
        [JsonProperty("role")]
        public Role Role { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[9|5|2][0-9]{7}", ErrorMessage = "Not a valid phone number")]
        [JsonProperty("tel")]
        public int Tel { get; set; }
        public DateTime DateC { get; set; }
        public int ScoreDelegate { get; set; }
        [JsonProperty("email")]
        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Password is required ")]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [NotMapped()]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Confirm password and password doesn't match, Type again !")]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }


        public List<Claim> ListClaims { get; set; }
        public List<Notice> ListNotices { get; set; }
        public List<JustificationAbsence> ListJustificationAdsences { get; set; }
        public List<Publication> ListPublications { get; set; }
        public List<Comment> LisCommentst { get; set; }
        public List<Child> ListChilds { get; set; }
        public SwitchAccount SwitchAccount { get; set; }
        public KinderGarten KinderGartenInscription { get; set; }
        public KinderGarten KinderGartenResponsible { get; set; }
        public KinderGarten kinderGartenDelegate { get; set; }
        public List<Consultation> ListConsultations { get; set; }
        public List<MedicalVisitKinderGarten> ListMedicalVisitKinderGartens { get; set; }
        public List<Spent> LisSpents { get; set; }
        public List<PayementSubscription> LisPayementSubscriptions { get; set; }
        public List<Reaction> LisReactions { get; set; }



        public override string ToString()
        {
            return "User : {" + Id + "," + Email + "," + Password + "," + Role + "}";
        }





    }
}
