﻿using System.ComponentModel.DataAnnotations;

namespace RegistryManagmentV2.Models.Domain
{
    public enum ResourceStatus
    {
        [Display(Name = "підтверджений адміном")]
        Approved,
        
        [Display(Name = "чекає підтвердження на створення")]
        PendingForCreationApprove,
        
        [Display(Name = "чекає підтвердження на зміну")]
        PendingForEditApprove
    }
}