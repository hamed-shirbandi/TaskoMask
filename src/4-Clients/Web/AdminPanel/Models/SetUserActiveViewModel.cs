﻿

namespace TaskoMask.Presentation.UI.AdminPanle.Models
{
    public class SetUserActiveViewModel
    {
        public SetUserActiveViewModel(string id,bool isActive)
        {
            Id = id;
            IsActive = isActive;
        }
        public string Id { get; set; }
        public bool IsActive { get; set; }
    }
}
