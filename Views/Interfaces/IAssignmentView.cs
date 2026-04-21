// File: Views/Interfaces/IAssignmentView.cs
using System;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface IAssignmentView
    {
        void SetAssignmentListBindingSource(BindingSource assignmentList);

        event EventHandler LoadEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
    }
}
