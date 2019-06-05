using System.Collections.Generic;
using ISPitanie.BLL.Entities;

namespace ISPitanie.Interfaces
{
    public interface ITypeService
    {
        void CreateType(Type type);                      //Добавить тип в БД

        IEnumerable<Type> GetTypes();                       //Вернуть все типы из БД

        Type GetType(System.String name);                            //Вернуть тип по имени

        void RemoveType(Type type);                      //Удалить тип из БД

        void Dispose();
    }
}