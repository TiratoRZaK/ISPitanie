using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using ISPitanie.BLL.Entities;
using ISPitanie.Infrastructure;
using ISPitanie.Interfaces;

namespace ISPitanie.Services
{
    public class UnitService : IUnitService
    {
        private IUnitOfWork db { get; set; }

        public UnitService(IUnitOfWork db)
        {
            this.db = db;
        }

        public void CreateUnit(Unit unit)
        {
            if (unit == null)
            {
                throw new ValidationException("Некорректная единица измерения", "");
            }
            UnitDTO unitDto = new UnitDTO
            {
                Name = unit.Name
            };
            db.Units.Create(unitDto);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Unit GetUnit(String name)
        {
            if (name == null)
                throw new ValidationException("Не верное наименование единицы измерения", "");
            var unit = db.Units.GetAll().Where(x => x.Name.Equals(name)).First();
            if (unit == null)
                throw new ValidationException("Единица измерения не найдена", "");
            return Mapper.Map<UnitDTO, Unit>(unit);
        }

        public IEnumerable<Unit> GetUnits()
        {
            return Mapper.Map<IEnumerable<UnitDTO>, List<Unit>>(db.Units.GetAll());
        }

        public void RemoveUnit(Unit unit)
        {
            if (unit == null)
            {
                throw new ValidationException("Данной единицы измерения не существует", "");
            }
            db.Units.Delete(unit.Id);
            db.Save();
        }
    }
}