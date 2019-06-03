using System;
using System.Collections.Generic;
using ISPitanie.BLL.Entities;

namespace ISPitanie.Interfaces
{
    public interface IUnitService
    {
        void CreateUnit(Unit unit);                      //Добавить единицу измерения в БД

        IEnumerable<Unit> GetUnits();                       //Вернуть все единицы измерения из БД

        Unit GetUnit(String name);                            //Вернуть единицу измерения по имени

        void RemoveUnit(Unit unit);                      //Удалить единицу измерения из БД

        void Dispose();
    }
}