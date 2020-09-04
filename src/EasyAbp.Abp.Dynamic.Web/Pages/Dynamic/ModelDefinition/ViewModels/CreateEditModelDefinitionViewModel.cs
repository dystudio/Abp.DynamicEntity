using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.Abp.Dynamic.Web.Pages.Dynamic.ModelDefinition.ViewModels
{
    public class CreateEditModelDefinitionViewModel
    {
        [Display(Name = "ModelDefinitionName")]
        public string Name { get; set; }

        [Display(Name = "ModelDefinitionDisplayName")]
        public string DisplayName { get; set; }

        [Display(Name = "ModelDefinitionType")]
        public string Type { get; set; }

        public List<SelectListItem> Fields { get; set; } = new List<SelectListItem>();

        [SelectItems(nameof(Fields))]
        [Display(Name = "FieldDefinition")]
        public List<Guid> FieldIds { get; set; } = new List<Guid>();
    }
}