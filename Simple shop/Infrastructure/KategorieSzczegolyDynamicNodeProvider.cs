﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using Simple_shop.DAL;
using Simple_shop.Models;

namespace Simple_shop.Infrastructure
{
    public class KategorieSzczegolyDynamicNodeProvider : DynamicNodeProviderBase
    {
        private KursyContext db = new KursyContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Kategoria kategoria in db.Kategorie)
            {
                DynamicNode node = new DynamicNode();
                node.Title = kategoria.NazwaKategorii;
                node.Key = "Kategoria_" + kategoria.KategoriaId;
                node.RouteValues.Add("nazwaKategori", kategoria.NazwaKategorii);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}
