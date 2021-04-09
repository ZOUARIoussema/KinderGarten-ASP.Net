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
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public Role Role { get; set; }
        public int Tel { get; set; }
        public DateTime DateC { get; set; }
        public int ScoreDelegate { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
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









    }
}
