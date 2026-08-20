using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbProperty
    {
        public int RevisionId { get; set; }
        public int PublicationState { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ReceivedFromCreatorService { get; set; }
        public bool ExplicitlyDeployable { get; set; }
        public bool? CanInstall { get; set; }
        public int? InstallationImpact { get; set; }
        public bool? InstallRequiresConnectivity { get; set; }
        public bool? InstallRequiresUserInput { get; set; }
        public int? InstallRebootBehavior { get; set; }
        public bool? CanUninstall { get; set; }
        public int? UninstallImpact { get; set; }
        public bool? UninstallRequiresConnectivity { get; set; }
        public bool? UninstallRequiresUserInput { get; set; }
        public int? UninstallRebootBehavior { get; set; }
        public int? HandlerId { get; set; }
        public Guid? EulaId { get; set; }
        public bool? RequiresReacceptanceOfEula { get; set; }
        public int? DefaultPropertiesLanguageId { get; set; }
        public string UpdateType { get; set; }
        public bool EulaExplicitlyAccepted { get; set; }
        public string MsrcSeverity { get; set; }
        public string CompatibleProtocolVersion { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
