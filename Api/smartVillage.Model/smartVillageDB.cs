using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace smartVillage.Model
{
    public class smartVillageDB : DbContext
    {

        public smartVillageDB()
            : base("name=smartVillageDB")
        {
        }


        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Village> Villages { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<CasteCertificate> CasteCertificates { get; set; }
        public virtual DbSet<CommunityCertificate> CommunityCertificates { get; set; }
        public virtual DbSet<DomicileCertificate> DomicileCertificates { get; set; }
        public virtual DbSet<RelationshipCertificate> RelationshipCertificates { get; set; }
        public virtual DbSet<IncomeCertificate> IncomeCertificates { get; set; }
        public virtual DbSet<IdentificationCertificate> IdentificationCertificates { get; set; }
        public virtual DbSet<NativityCertificate> NativityCertificates { get; set; }
        public virtual DbSet<FamilyMembershipCertificate> FamilyMembershipCertificates { get; set; }
        public virtual DbSet<NonCreamyLayerCertificate> NonCreamyLayerCertificates { get; set; }
        public virtual DbSet<Caste> Castes { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }

        public virtual DbSet<Vayomadhuram> Vayomadhurams { get; set; }
        public virtual DbSet<Medisep> Mediseps { get; set; }
        public virtual DbSet<Snehapoorvam> Snehapoorvams { get; set; }

        public virtual DbSet<IndiraGandhiNationalOldAgePension> IndiraGandhiNationalOldAgePensions { get; set; }
        public virtual DbSet<AgricultureWorkersPension> AgricultureWorkersPensions { get; set; }
        public virtual DbSet<UnmarriedWomenPension> UnmarriedWomenPensions { get; set; }
        public virtual DbSet<IndiraGandhiNationalWidowPension> IndiraGandhiNationalWidowPensions { get; set; }
        public virtual DbSet<IndiraGandhiNationalDisabilityPension> IndiraGandhiNationalDisabilityPensions { get; set; }

    }


}