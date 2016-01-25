using System;
using System.ComponentModel.DataAnnotations;

namespace AxpCaller.ViewModels
{
    public class ActivateViewModel
    {
        [Required]
        public string CompanyID { get; set; }

    }

}