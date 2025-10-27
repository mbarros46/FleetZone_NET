using FleetZone_NET.Application.DTOs;
using System.Collections.Generic;

namespace FleetZone_NET.Application.Validation
{
    // Lightweight validator helper to avoid FluentValidation runtime dependency.
    // Returns a dictionary of field -> error messages when validation fails.
    public static class MotocicletaRequestValidator
    {
        public static IDictionary<string, string[]> Validate(MotocicletaRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (string.IsNullOrWhiteSpace(request.Placa))
            {
                errors["Placa"] = new[] { "Placa is required." };
            }
            else if (request.Placa.Length > 10)
            {
                errors["Placa"] = new[] { "Placa must be at most 10 characters." };
            }

            if (request.PatioId == Guid.Empty)
            {
                errors["PatioId"] = new[] { "PatioId must be a valid GUID." };
            }

            return errors;
        }
    }
}
