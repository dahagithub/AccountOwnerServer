using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using Entities.ExtendedModels;
using Entities.Extentions;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext respositoryContext) : base(respositoryContext)
        {
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll().OrderBy(ow => ow.Name).ToList();
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId)).FirstOrDefault();
        }

        public OwnerExtended GetOwnerWithDetails(Guid ownerId)
        {
            OwnerExtended ownerEx = null;
            Owner owner = null;
               try
            {
                owner = GetOwnerById(ownerId);
                if( owner == null)
                {
                    return ownerEx;
                }
                else
                {
                    return new OwnerExtended(owner)
                    {
                        Accounts = RepositoryContext.Accounts.Where(a => a.OwnerId == ownerId)
                    };
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            Create(owner);
        }

        public void UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Map(owner);
            Update(dbOwner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }
    }
}
