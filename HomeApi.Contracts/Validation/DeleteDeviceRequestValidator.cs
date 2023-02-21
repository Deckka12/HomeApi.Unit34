using FluentValidation;
using HomeApi.Contracts.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Validation {
     class DeleteDeviceRequestValidator : AbstractValidator<EditDeviceRequest> {
        /// <summary>
        /// Метод, конструктор, устанавливающий правила
        /// </summary>
        public DeleteDeviceRequestValidator () {
            RuleFor(x => x.NewName).NotEmpty();
            RuleFor(x => x.NewRoom).NotEmpty().Must(BeSupported)
                .WithMessage($"Please choose one of the following locations: {string.Join(", ", Values.ValidRooms)}");
        }

        /// <summary>
        ///  Метод кастомной валидации для свойства location
        /// </summary>
        private bool BeSupported (string location) {
            return Values.ValidRooms.Any(e => e == location);
        }
    }
}
