using System.Collections;
using System.Collections.Generic;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.Infrastructure.Interfaces
{
    public interface IFieldsRepository
    {
        IEnumerable<InfrastructureField> GetAllFields();

        InfrastructureField GetField(int fieldId);

        void CreateField(InfrastructureField field);

        void DeleteField(int fieldId);
    }
}
