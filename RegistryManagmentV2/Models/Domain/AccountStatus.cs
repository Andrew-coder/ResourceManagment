using System.ComponentModel.DataAnnotations;

namespace RegistryManagmentV2.Models.Domain
{
    public enum AccountStatus
    {
        [Display(Name = "в очікуванні підтвердження")]
        PendingApproval,
        
        [Display(Name = "підтверджений адміністратором")]
        Approved
    }
}