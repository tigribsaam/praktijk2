﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class ArtRepository: IArtRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public ArtRepository(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }

        public IEnumerable<Art> AllArt
        {
            get
            {
                return _appDbContext.Art;
            }
        }

        public Art GetArtById(int ArtId)
        {
            return _appDbContext.Art.FirstOrDefault(async => async.ArtId == ArtId);
        }

        public void CreateArt(Art art)
        {
            art.Available = true;
            _appDbContext.Art.Add(art);
            _appDbContext.SaveChanges();

        }

        public void DeleteArt(Art art)
        {
            List<ShoppingCartItem> items = new List<ShoppingCartItem>
            {

            };

            foreach (var Item in _appDbContext.ShoppingCartItems)
            {
                if (Item.Art == art)
                {
                    items.Add(Item);
                }
            }
            var selectedArt = _appDbContext.ShoppingCartItems.FirstOrDefault(a => a.Art == art);

            _appDbContext.RemoveRange(items);

            _appDbContext.Remove<Art>(art);
            _appDbContext.SaveChanges();
        }
    }
}