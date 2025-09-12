using BusinessPortal.Models;
using System.Collections.ObjectModel;

namespace BusinessPortal.ViewModels
{
    public class PortalViewModel : BaseViewModel
    {
        // ObservableCollection is a special list that automatically notifies the UI when items are added or removed.
        public ObservableCollection<ServiceModule> Services { get; }

        public PortalViewModel()
        {
            // Create some mock/sample data for the services.
            // Later, this data will come from a database or an API call.
            Services = new ObservableCollection<ServiceModule>
            {
                new ServiceModule { Name = "CRM", Description = "Manage your customer relationships." },
                new ServiceModule { Name = "Invoicing", Description = "Create and track invoices." },
                new ServiceModule { Name = "Project Management", Description = "Organize and plan your projects." },
                new ServiceModule { Name = "HR Portal", Description = "Handle employee information and payroll." }
            };
        }
    }
}

