using System;

namespace Zoe.MsSample.Application.ViewModels
{
    public class UpdateCustomerViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
