using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using ISPitanie.BLL.Entities;
using ISPitanie.Infrastructure;
using ISPitanie.Interfaces;
using Type = ISPitanie.BLL.Entities.Type;

namespace ISPitanie.Services
{
    public class TypeService : ITypeService
    {
        private IUnitOfWork db { get; set; }

        public TypeService(IUnitOfWork db)
        {
            this.db = db;
        }

        public void CreateType(Type type)
        {
            if (type == null)
            {
                throw new ValidationException("Некорректная единица измерения", "");
            }
            TypeDTO typeDto = new TypeDTO
            {
                Name = type.Name
            };
            db.Types.Create(typeDto);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Type GetType(String name)
        {
            if (name == null)
                throw new ValidationException("Не верное наименование единицы измерения", "");
            var type = db.Types.GetAll().Where(x => x.Name.Equals(name)).First();
            if (type == null)
                throw new ValidationException("Единица измерения не найдена", "");
            return Mapper.Map<TypeDTO, Type>(type);
        }

        public IEnumerable<Type> GetTypes()
        {
            return Mapper.Map<IEnumerable<TypeDTO>, List<Type>>(db.Types.GetAll());
        }

        public void RemoveType(Type type)
        {
            if (type == null)
            {
                throw new ValidationException("Данной единицы измерения не существует", "");
            }
            db.Types.Delete(type.Id);
            db.Save();
        }
    }
}