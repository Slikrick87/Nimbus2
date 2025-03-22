using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Services;


namespace Nimbus.Shared.Components
{
    public partial class AddAddressToRouteDialog : ComponentBase
    {
        public Address Address { get; set; } =
            new Address(1, "Two", "Three", "Ky", 12345);

        [Inject]
        public IAddressRepository? AddressRepository { get; set; }

        public bool ShowDialog { get; set; }
        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }
        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
        private void ResetDialog()
        {
            Address = new Address();
        }
    }
}
