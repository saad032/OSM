﻿using System.Collections.Generic;
using System.Linq;
using OSM.Interfaces.IServices;
using OSM.Interfaces.Repository;
using OSM.Models.MenuModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OSM.Implementation.Services
{
    /// <summary>
    /// Menu Rights Service
    /// </summary>
    public sealed class MenuRightsService: IMenuRightsService
    {
        #region Private

        private readonly IMenuRightRepository menuRightRepository;
        private readonly IMenuRepository menuRepository;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuRightsService(IMenuRightRepository menuRightRepository, IMenuRepository menuRepository)
        {
            this.menuRightRepository = menuRightRepository;
            this.menuRepository = menuRepository;
        }

        #endregion

        #region Public
        /// <summary>
        /// Find Menu Items by Role ID
        /// </summary>
        public IEnumerable<MenuRight> FindMenuItemsByRoleId(string roleId)
        {
            return menuRightRepository.GetMenuByRole(roleId).ToList();
        }

        public UserMenuResponse SaveRoleMenuRight(string roleId, string menuIds, IdentityRole role)
        {
            List<IdentityRole> Roles = menuRepository.Roles().OrderBy(dbRole => dbRole.Name).ToList();
            List<Menu> menues = menuRepository.GetAll().ToList();
            IList<string> postedMenuIdstrings = menuIds.Split(new[] { ',' });
            IList<int> postedMenuIds = new List<int>();
            if (postedMenuIdstrings.Count > 0 && !string.IsNullOrEmpty(postedMenuIdstrings[0]))
                postedMenuIds = postedMenuIdstrings.Select(int.Parse).ToList();
            List<MenuRight> userMenuRights = menuRightRepository.GetMenuByRole(roleId).ToList();

            foreach (int menuItem in postedMenuIds)
            {
                if (userMenuRights.All(right => right.Menu.MenuId != menuItem))
                {
                    MenuRight toBeAddedMenu = new MenuRight { Menu = menues.FirstOrDefault(dbMenu => dbMenu.MenuId == menuItem), Role = Roles.FirstOrDefault(dbRole => dbRole.Id == roleId) };
                    menuRightRepository.Add(toBeAddedMenu);
                }
            }

            IEnumerable<MenuRight> deleted = userMenuRights.Where(menu => !postedMenuIds.Contains(menu.Menu.MenuId));
            deleted.ToList().ForEach(menu => menuRightRepository.Delete(menu));
            menuRightRepository.SaveChanges();
            return new UserMenuResponse
            {
                MenuRights = FindMenuItemsByRoleId(roleId).ToList(),
                Menus = menuRepository.GetAll().ToList(),
                Roles = Roles
            };
        }

        public UserMenuResponse GetRoleMenuRights(string roleId)
        {
            List<IdentityRole> Roles = menuRepository.Roles().OrderBy(role => role.Name).ToList();
            return new UserMenuResponse
            {
                Roles = Roles,
                MenuRights = FindMenuItemsByRoleId(string.IsNullOrEmpty(roleId) ? Roles[0].Id : roleId).ToList(),
                Menus = menuRepository.GetAll().ToList(),
            };
        }

        #endregion
    }
}
