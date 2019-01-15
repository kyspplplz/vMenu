using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using static vMenuShared.ConfigManager;
using static vMenuShared.PermissionsManager;
using static CitizenFX.Core.BaseScript;
using MenuAPI;

namespace vMenuClient
{
    public static class IplManager
    {
        // Exports dictionary used to call exports. This is impossible to do directly from BaseScript itself for some stupid reason.
        private static readonly ExportDictionary Exports = new ExportDictionary();

        private static string resourceName = "bob74_ipl";

        internal static List<Interior> interiors = new List<Interior>();

        /// <summary>
        /// Checks if the dependency for the ipl menu is present and enabled via the config option in the __resource.lua of the ipl resource.
        /// </summary>
        /// <returns></returns>
        internal static bool IsDependencyPresentAndEnabled()
        {
            var resCount = GetNumResources();
            bool found = false;
            for (int i = 0; i < resCount; i++)
            {
                // Get the resource name.
                string name = GetResourceByFindIndex(i);

                // resource name is invalid or missing, skip this resource.
                if (string.IsNullOrEmpty(name))
                    continue;

                // resource is not started, skip this resource.
                if (GetResourceState(name) != "started")
                    continue;

                // we don't want to check for vMenu itself.
                if (GetCurrentResourceName() == name)
                    continue;

                // Get the metadata to see if this is bob's IPL resource and if it's integration is enabled or disabled.
                string metadata = GetResourceMetadata(name, "enable_vmenu_bob74_ipl_integration", 0);

                // invalid or no meta data present.
                if (string.IsNullOrEmpty(metadata))
                    continue;

                // found and enabled.
                if (metadata.ToLower() == "true")
                {
                    found = true;
                    resourceName = name;
                    break;
                }
                // found, but not enabled.
                else if (metadata.ToLower() == "false")
                {
                    break;
                }
            }

            // If it's not found or not enabled by the IPL's config, then return false.
            if (!found)
                return false;

            return true;
        }

        /// <summary>
        /// Checks if the ipl integration with bob74's ipl resource is enabled.
        /// </summary>
        /// <returns></returns>
        internal static bool IsIplIntegrationEnabled()
        {
            // Check if the dependency is present and enabled.
            if (IsDependencyPresentAndEnabled())
            {
                // Check if the setting in vMenu is enabled.
                if (GetSettingsBool(Setting.vmenu_enable_bob74_ipl_integration))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Loads interiors from default setup.
        /// </summary>
        internal static void LoadAllInteriors()
        {
            if (IsIplIntegrationEnabled())
            {
                // Apartments
                #region apartments
                AddInterior(new Apartment("4 Integrity Way, Apt 30", MainMenu.IplManagementMenu.apartmentsMenu)
                {
                    iplObject = Exports[resourceName].GetGTAOApartmentHi1Object(),
                    posTpInt = new Vector3(-18.61f, -581.87f, 90.11f),
                    posTpExt = new Vector3(-48.95f, -588.96f, 37.59f),
                    teleportHeading = 73.58f,
                    interiorLocation = new Vector3(-29.49f, -581.29f, 88.71f),
                    TvPosition = new Vector3(-40.24f, -571.05f, 88.92f)
                });

                AddInterior(new Apartment("Dell Perro Heights, Apt 7", MainMenu.IplManagementMenu.apartmentsMenu)
                {
                    iplObject = Exports[resourceName].GetGTAOApartmentHi2Object(),
                    posTpInt = new Vector3(-1458.32f, -520.78f, 56.93f),
                    posTpExt = new Vector3(-1446.7f, -538.99f, 34.74f),
                    teleportHeading = 126.62f,
                    interiorLocation = new Vector3(-1465.84f, -530.33f, 55.53f),
                    TvPosition = new Vector3(-1479.18f, -531.98f, 55.74f),
                });
                #endregion

                // High Life apartments
                #region High Life Apartments

                #endregion

                // Penthouses 
                #region penthouses
                AddInterior(new Penthouse("EclipseTowers, Penthouse Suite 1", MainMenu.IplManagementMenu.apartmentsMenu)
                {
                    iplObject = Exports[resourceName].GetExecApartment1Object(),
                    posTpInt = new Vector3(-781.7f, 318.62f, 217.67f),
                    posTpExt = new Vector3(-777.48f, 312.71f, 85.7f),
                    teleportHeading = 40.98f,
                    interiorLocation = new Vector3(-786.9f, 330.32f, 217.04f),
                    TvPosition = new Vector3(-781.74f, 337.91f, 216.84f),
                });

                AddInterior(new Penthouse("EclipseTowers, Penthouse Suite 2", MainMenu.IplManagementMenu.apartmentsMenu, 5)
                {
                    iplObject = Exports[resourceName].GetExecApartment2Object(),
                    posTpInt = new Vector3(-779.25f, 338.95f, 196.69f),
                    posTpExt = new Vector3(-777.48f, 312.71f, 85.7f),
                    teleportHeading = 40.98f,
                    interiorLocation = new Vector3(-773.2258f, 322.8252f, 194.8862f),
                    TvPosition = new Vector3(-780.61f, 319.28f, 194.88f),
                });

                AddInterior(new Penthouse("EclipseTowers, Penthouse Suite 3", MainMenu.IplManagementMenu.apartmentsMenu, 3)
                {
                    iplObject = Exports[resourceName].GetExecApartment3Object(),
                    posTpInt = new Vector3(-781.82f, 318.93f, 187.92f),
                    posTpExt = new Vector3(-777.48f, 312.71f, 85.7f),
                    teleportHeading = 40.98f,
                    interiorLocation = new Vector3(-787.7805f, 334.9232f, 186.1134f),
                    TvPosition = new Vector3(-780.36f, 338.47f, 186.11f),
                });
                #endregion
                {
                    iplObject = Exports[resourceName].GetGTAOApartmentHi1Object(),
                    posInt = new Vector3(-35.3127f, -580.4199f, 88.71221f),
                    posExt = Vector3.Zero,
                    TvPosition = new Vector3(-40.24f, -571.05f, 88.92f)
                });

                AddInterior(new Apartment("Dell Perro Heights, Apt 7", MainMenu.IplManagementMenu.apartmentsMenu)
                {
                    iplObject = Exports[resourceName].GetGTAOApartmentHi2Object(),
                    posInt = new Vector3(-1477.14f, -538.7499f, 55.5264f),
                    posExt = Vector3.Zero,
                    TvPosition = new Vector3(-1479.18f, -531.98f, 55.74f),
                });

                AddInterior(new Penthouse("EclipseTowers, Penthouse Suite 1", MainMenu.IplManagementMenu.apartmentsMenu)
                {
                    iplObject = Exports[resourceName].GetExecApartment1Object(),
                    posInt = new Vector3(-787.7805f, 334.9232f, 215.8384f),
                    posExt = Vector3.Zero,
                    TvPosition = new Vector3(-781.74f, 337.91f, 216.84f),
                });

            }

        }

        /// <summary>
        /// Loads cusomizations that were saved to the server.
        /// </summary>
        internal static void LoadAllCustomizationOptions()
        {
            // todo.
        }

        /// <summary>
        /// Saves the interior customization to the server.
        /// </summary>
        /// <param name="interior"></param>
        internal static void SaveCustomizationOptions(Interior interior)
        {
            // todo.
        }

        /// <summary>
        /// Adds an interior to the list of interiors.
        /// </summary>
        /// <param name="interior"></param>
        /// <returns>Returns the interior that was added.</returns>
        private static Interior AddInterior(Interior interior)
        {
            interiors.Add(interior);
            return interior;
        }

        //internal enum InteriorType { house, highLifeApartment, penthouse, office, warehouse, cocaineLockup, methLab, weedFarm, forgery, factory, clubhouse1, clubhouse2, garages, vehicleWarehouse, bunker, hangar, facility, clubhouse, arena, arena_vip, arena_garage1, arena_garage2, arena_garage3 }

        /// <summary>
        /// Interior class used for managing the interior data.
        /// </summary>
        internal class Interior
        {
            internal string name = null; // The interior display name.
            internal dynamic iplObject;

            internal Vector3 posTpInt = Vector3.Zero; // interior teleport location in the world.
            internal Vector3 posTpExt = Vector3.Zero; // exterior teleport location in the world.

            internal float teleportHeading = 0f;
            internal Vector3 interiorLocation = Vector3.Zero; // used to get the interior ID, interior ID at the posInt (entrance) is usually NOT the correct interior ID.

            internal Vector3 TvPosition { get; set; } = Vector3.Zero;

            //internal int InteriorId => iplObject != null ? (((System.Dynamic.ExpandoObject)iplObject).Any(k => k.Key == "interiorId")) ? (int)iplObject.interiorId : (int)iplObject.currentInteriorId : 0;
            internal int InteriorId => GetInteriorAtCoords(interiorLocation.X, interiorLocation.Y, interiorLocation.Z);

            internal Menu Menu { get; set; }
            internal MenuItem tpButton = new MenuItem("Teleport To Interior", "Teleport directly to the interior.");

            internal Interior(string name, Menu parentMenu)
            {
                this.name = name;
                Menu = new Menu("Interior Options", name ?? "n/a");
                Menu.AddMenuItem(tpButton);
                Menu.OnItemSelect += (sender, item, index) =>
                {
                    if (item == tpButton)
                    {
                        TeleportToInterior();
                    }
                };
                MenuController.AddSubmenu(parentMenu, Menu);
                var menuBindItem = new MenuItem(name, $"Manage {name} interior options.") { Label = "→→→" };
                parentMenu.AddMenuItem(menuBindItem);
                MenuController.BindMenuItem(parentMenu, Menu, menuBindItem);
            }

            internal async void TeleportToInterior()
            {
                RequestCollisionAtCoord(posTpInt.X, posTpInt.Y, posTpInt.Z);
                DoScreenFadeOut(500);
                while (!IsScreenFadedOut())
                {
                    await Delay(0);
                }
                RequestCollisionAtCoord(posTpInt.X, posTpInt.Y, posTpInt.Z);
                SetEntityCoordsNoOffset(PlayerPedId(), posTpInt.X, posTpInt.Y, posTpInt.Z, false, false, false);
                SetEntityHeading(Game.PlayerPed.Handle, teleportHeading);
                DoScreenFadeIn(500);
            }
        }

        /// <summary>
        /// Apartment class, is a type of interior.
        /// </summary>
        internal class Apartment : Interior
        {
            // Is low end or mid end house, used for smoke state differences.
            internal bool IsMidOrLowEnd = false;

            // Clothing strip states
            internal bool StripA { get; private set; } = false;
            internal bool StripB { get; private set; } = false;
            internal bool StripC { get; private set; } = false;

            // Booze states
            internal bool BoozeA { get; private set; } = false;
            internal bool BoozeB { get; private set; } = false;
            internal bool BoozeC { get; private set; } = false;

            // Smoke states
            internal bool SmokeA { get; private set; } = false;
            internal bool SmokeB { get; private set; } = false;
            internal bool SmokeC { get; private set; } = false;

            /// <summary>
            /// Sets the strip clothes state.
            /// </summary>
            /// <param name="stripA"></param>
            /// <param name="stripB"></param>
            /// <param name="stripC"></param>
            /// <param name="refresh"></param>
            internal void SetStrip(bool stripA, bool stripB, bool stripC, bool refresh)
            {
                StripA = stripA;
                StripB = stripB;
                StripC = stripC;

                iplObject.Strip.Enable(iplObject.Strip.A, stripA, refresh);
                iplObject.Strip.Enable(iplObject.Strip.B, stripB, refresh);
                iplObject.Strip.Enable(iplObject.Strip.C, stripC, refresh);
            }

            /// <summary>
            /// Sets the booze state.
            /// </summary>
            /// <param name="boozeA"></param>
            /// <param name="boozeB"></param>
            /// <param name="boozeC"></param>
            /// <param name="refresh"></param>
            internal void SetBooze(bool boozeA, bool boozeB, bool boozeC, bool refresh)
            {
                BoozeA = boozeA;
                BoozeB = boozeB;
                BoozeC = boozeC;

                iplObject.Booze.Enable(iplObject.Booze.A, boozeA, refresh);
                iplObject.Booze.Enable(iplObject.Booze.B, boozeB, refresh);
                iplObject.Booze.Enable(iplObject.Booze.C, boozeC, refresh);
            }

            /// <summary>
            /// Sets the smoke state.
            /// </summary>
            /// <param name="smokeA"></param>
            /// <param name="smokeB"></param>
            /// <param name="smokeC"></param>
            /// <param name="refresh"></param>
            internal void SetSmoke(bool smokeA, bool smokeB, bool smokeC, bool refresh)
            {
                SmokeA = smokeA;
                SmokeB = smokeB;
                SmokeC = smokeC;

                if (IsMidOrLowEnd || this is Penthouse)
                {
                    // clear smoke
                    iplObject.Smoke.Clear(refresh);

                    // Smoke a, b, c or none.
                    iplObject.Smoke.Set(SmokeA ? iplObject.Smoke.stage1 : SmokeB ? iplObject.Smoke.stage2 : SmokeC ? iplObject.Smoke.stage3 : iplObject.Smoke.none);
                }
                else
                {
                    iplObject.Smoke.Enable(iplObject.Smoke.A, smokeA, refresh);
                    iplObject.Smoke.Enable(iplObject.Smoke.B, smokeB, refresh);
                    iplObject.Smoke.Enable(iplObject.Smoke.C, smokeC, refresh);
                }
            }

            const string toggle_prop_desc = "Toggle this interior prop.";
            public Apartment(string name, Menu parentMenu) : base(name, parentMenu)
            {
                Menu propsSubmenu = new Menu("Interior Props", "enable or disable props");

                MenuCheckboxItem stripABtn = new MenuCheckboxItem("Strip A", toggle_prop_desc, StripA);
                MenuCheckboxItem stripBBtn = new MenuCheckboxItem("Strip B", toggle_prop_desc, StripB);
                MenuCheckboxItem stripCBtn = new MenuCheckboxItem("Strip C", toggle_prop_desc, StripC);

                MenuCheckboxItem boozeABtn = new MenuCheckboxItem("Booze A", toggle_prop_desc, BoozeA);
                MenuCheckboxItem boozeBBtn = new MenuCheckboxItem("Booze B", toggle_prop_desc, BoozeB);
                MenuCheckboxItem boozeCBtn = new MenuCheckboxItem("Booze C", toggle_prop_desc, BoozeC);

                MenuCheckboxItem smokeABtn = new MenuCheckboxItem("Smoke A", toggle_prop_desc, SmokeA);
                MenuCheckboxItem smokeBBtn = new MenuCheckboxItem("Smoke B", toggle_prop_desc, SmokeB);
                MenuCheckboxItem smokeCBtn = new MenuCheckboxItem("Smoke C", toggle_prop_desc, SmokeC);

                int stage = SmokeA ? 1 : SmokeB ? 2 : SmokeC ? 3 : 0;
                MenuListItem smokeList = new MenuListItem("Smoke Stage", new List<string>() { "No Smoke", "Smoke Stage A", "Smoke Stage B", "Smoke Stage C" }, stage, "Set a smoke props stage/style.");

                propsSubmenu.AddMenuItem(stripABtn);
                propsSubmenu.AddMenuItem(stripBBtn);
                propsSubmenu.AddMenuItem(stripCBtn);

                propsSubmenu.AddMenuItem(boozeABtn);
                propsSubmenu.AddMenuItem(boozeBBtn);
                propsSubmenu.AddMenuItem(boozeCBtn);

                if (IsMidOrLowEnd || this is Penthouse)
                {
                    propsSubmenu.AddMenuItem(smokeList);
                }
                else
                {
                    propsSubmenu.AddMenuItem(smokeABtn);
                    propsSubmenu.AddMenuItem(smokeBBtn);
                    propsSubmenu.AddMenuItem(smokeCBtn);
                }


                propsSubmenu.OnListIndexChange += (sender, item, oldIndex, newIndex, itemIndex) =>
                {
                    if (item == smokeList)
                    {
                        if (newIndex == 0)
                        {
                            SmokeA = false;
                            SmokeB = false;
                            SmokeC = false;
                        }
                        else if (newIndex == 1)
                        {
                            SmokeA = true;
                            SmokeB = false;
                            SmokeC = false;
                        }
                        else if (newIndex == 2)
                        {
                            SmokeA = false;
                            SmokeB = true;
                            SmokeC = false;
                        }
                        else if (newIndex == 3)
                        {
                            SmokeA = false;
                            SmokeB = false;
                            SmokeC = true;
                        }
                        SetSmoke(SmokeA, SmokeB, SmokeC, true);
                    }
                };


                MenuController.AddSubmenu(Menu, propsSubmenu);

                MenuItem propsMenuBtn = new MenuItem("Interior Props", "Enable or disable interior props.") { Label = "→→→" };

                Menu.AddMenuItem(propsMenuBtn);

                MenuController.BindMenuItem(Menu, propsSubmenu, propsMenuBtn);



                propsSubmenu.OnCheckboxChange += (sender, item, index, _checked) =>
                {
                    // smoke
                    if (item == smokeABtn)
                    {
                        SmokeA = _checked;
                        SetSmoke(SmokeA, SmokeB, SmokeC, true);
                    }
                    else if (item == smokeBBtn)
                    {
                        SmokeB = _checked;
                        SetSmoke(SmokeA, SmokeB, SmokeC, true);
                    }
                    else if (item == smokeCBtn)
                    {
                        SmokeC = _checked;
                        SetSmoke(SmokeA, SmokeB, SmokeC, true);
                    }

                    // booze
                    else if (item == boozeABtn)
                    {
                        BoozeA = _checked;
                        SetBooze(BoozeA, BoozeB, BoozeC, true);
                    }
                    else if (item == boozeBBtn)
                    {
                        BoozeB = _checked;
                        SetBooze(BoozeA, BoozeB, BoozeC, true);
                    }
                    else if (item == boozeCBtn)
                    {
                        BoozeC = _checked;
                        SetBooze(BoozeA, BoozeB, BoozeC, true);
                    }

                    // strip
                    else if (item == stripABtn)
                    {
                        StripA = _checked;
                        SetStrip(StripA, StripB, StripC, true);
                    }
                    else if (item == stripBBtn)
                    {
                        StripB = _checked;
                        SetStrip(StripA, StripB, StripC, true);
                    }
                    else if (item == stripCBtn)
                    {
                        StripC = _checked;
                        SetStrip(StripA, StripB, StripC, true);
                    }
                };
            }
        }

        internal class Penthouse : Apartment
        {
            internal int Style { get; private set; } = 0;
            List<dynamic> styles = new List<dynamic>();

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="name"></param>
            /// <param name="parentMenu"></param>
            internal Penthouse(string name, Menu parentMenu) : this(name, parentMenu, 0) { }
            /// <summary>
            /// Constructor overload with style option.
            /// </summary>
            /// <param name="name"></param>
            /// <param name="parentMenu"></param>
            /// <param name="style"></param>
            internal Penthouse(string name, Menu parentMenu, int style) : base(name, parentMenu)
            {
                Style = style;

                MenuListItem stylesList = new MenuListItem("Penthouse Style", new List<string>() { "Modern", "Moody", "Vibrant", "Sharp", "Monochrome", "Seductive", "Regal", "Aqua" }, Style, "Select a penthouse style.");
                Menu.AddMenuItem(stylesList);

                Menu.OnListIndexChange += (sender, item, oldIndex, newIndex, itemIndex) =>
                {
                    if (item == stylesList)
                    {
                        SetStyle(newIndex);
                    }
                };
            }


            /// <summary>
            /// Set the interior penthouse style.
            /// </summary>
            /// <param name="styleIndex"></param>
            internal void SetStyle(int styleIndex)
            {
                if (styles.Count == 0)
                {
                    styles.Add(iplObject.Style.Theme.modern);
                    styles.Add(iplObject.Style.Theme.moody);
                    styles.Add(iplObject.Style.Theme.vibrant);
                    styles.Add(iplObject.Style.Theme.sharp);
                    styles.Add(iplObject.Style.Theme.monochrome);
                    styles.Add(iplObject.Style.Theme.seductive);
                    styles.Add(iplObject.Style.Theme.regal);
                    styles.Add(iplObject.Style.Theme.aqua);
                }
                Style = styleIndex;

                iplObject.Style.Set(styles[styleIndex], true);

                SetStrip(StripA, StripB, StripC, true);
                SetBooze(BoozeA, BoozeB, BoozeC, true);
                SetSmoke(SmokeA, SmokeB, SmokeC, true);
            }

        }


        internal class House : Apartment
        {
            internal House(string name, Menu parentMenu) : base(name, parentMenu)
            {

            }
        }
    }


}
