// File: Views/Interfaces/IUserView.cs
using System;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface IUserView
    {
        void SetUserListBindingSource(BindingSource userList);
        event EventHandler LoadEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
    }
}
