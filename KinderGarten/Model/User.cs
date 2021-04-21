using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        [JsonProperty("firstName")]
        public String FirstName { get; set; }
        [JsonProperty("lastName")]
        public String LastName { get; set; }
        [JsonProperty("address")]
        public String Address { get; set; }
        [JsonProperty("role")]
        public Role Role { get; set; }
        [JsonProperty("tel")]
        public int Tel { get; set; }
        [JsonProperty("dateC")]
        public DateTime DateC { get; set; }
        [JsonProperty("scoreDelegate")]
        public int ScoreDelegate { get; set; }
        [JsonProperty("email")]
        public String Email { get; set; }
        [JsonProperty("password")]
        public String Password { get; set; }
        public List<Claim> ListClaims { get; set; } 
        public List<Notice> ListNotices { get; set; }
        public List<JustificationAbsence> ListJustificationAdsences { get; set; }
        public List<Publication> ListPublications { get; set; }
        public List<Comment> LisCommentst { get; set; }
        public List<Child> ListChilds { get; set; }
        [JsonProperty("switchAccount")]
        public SwitchAccount SwitchAccount { get; set; }
        [JsonProperty("kinderGartenInscription")]
        public KinderGarten KinderGartenInscription { get; set; }
        [JsonProperty("kinderGartenResponsible")]
        public KinderGarten KinderGartenResponsible { get; set; }
        [JsonProperty("kinderGartenDelegate")]
        public KinderGarten KinderGartenDelegate { get; set; }
        public List<Consultation> ListConsultations { get; set; }
        public List<MedicalVisitKinderGarten> ListMedicalVisitKinderGartens { get; set; }
        public List<Spent> LisSpents { get; set; }
        public List<PayementSubscription> LisPayementSubscriptions { get; set; }
        public List<Reaction> LisReactions { get; set; }









    }
}
