﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Newtonsoft.Json;

namespace RegistryManagmentV2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ResourceViewModel
    {
        public int? Id { get; set; }
        [Required] 
        [Display(Name = "Назва")] 
        public string Title { get; set; }
        
        [Required] 
        [Display(Name = "Опис")] 
        public string Description { get; set; }
        
        [Required] 
        [Display(Name = "Мова")] 
        public string Language { get; set; }
        
        [Required] 
        [Display(Name = "Формат")] 
        public string Format { get; set; }

        [DefaultValue(5)]
        [Range(1, 10)]
        [Display(Name = "Рівень доступу")]
        public int SecurityLevel { get; set; }

        [Required]
        [Display(Name="Файл")]
        public HttpPostedFileBase ResourceFile { get; set; }
    
        [Required]
        [Display(Name="Розташування файла")]
        public string ResourceLocation { get; set; }

        [Display(Name = "Пріоритет")]
        public int? Priority { get; set; }

        public int? CatalogId { get; set; }

        [Display(Name = "Теги")]
        public virtual string Tags { get; set; }
    }

    public class UpdateResourceViewModel
    {
        public int? Id { get; set; }
        [Required]
        [Display(Name = "Назва")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Мова")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Формат")]
        public string Format { get; set; }

        [DefaultValue(5)]
        [Range(1, 10)]
        [Display(Name = "Рівень доступу")]
        public int SecurityLevel { get; set; }

        [Display(Name = "Файл")]
        public HttpPostedFileBase ResourceFile { get; set; }

        [Display(Name = "Пріоритет")]
        public int? Priority { get; set; }

        public int? CatalogId { get; set; }

        [Display(Name = "Теги")]
        public virtual string Tags { get; set; }
    }

    public class CatalogViewModel
    {
        [Required]
        public int Id { get; set; }
        public int? CatalogId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [DefaultValue(5)]
        [Range(1, 10)]
        [Display(Name = "Рівень доступу")]
        public int SecurityLevel { get; set; }
        [Display(Name = "Groups")]
        public string Groups { get; set; }
    }

    public class SearchViewModel
    {
        public string Tags { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Емейл")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запамятати мене?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Імя")]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Емейл")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль {0} повинен містити хоча б {2} символи.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        [Compare("Password", ErrorMessage = "Пароль і пароль для підтвердження повинні співпадати.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Емейл")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль {0} повинен містити хоча б {2} символи.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        [Compare("Password", ErrorMessage = "Обидва паролі повинні співпадати")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ApplicationUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Статус акаунта")]
        public string AccountStatus { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Емейл")]
        public string Email { get; set; }

        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Кількість невдалих спроб авторизація")]
        public int AccessFailedCount { get; set; }

        [Required]
        [Display(Name = "Імя")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Група")]
        public string UserGroup { get; set; }
    }
}
