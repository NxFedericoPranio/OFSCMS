using DataClasses.DataModel.Menu;
using DataClasses.OFS.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataClasses.DataModel.Generic
{
    public class OFSObjectGenericForManyInOneFile : IOFSObjects
    {
        internal OFSObjectGenericForManyInOneFile()
        {
        }

        public OFSObjectGenericForManyInOneFile(string Path)
        {
            this.Path = Path;
        }

        Serializator serializator = new Serializator();

        public string Path
        {
            get;
            set;
        }

        public IOFSObject Get<T>(string id, string language)
        {
            OFSMenuesXml menu = new OFSMenuesXml(Path);
            var list = menu.GetAll<OFSMenu>().ConvertAll<OFSMenu>(new Converter<IOFSObject,OFSMenu>(ConvertOFSMenu));
            return getItem(list, id, language);
        }

        public static OFSMenu ConvertOFSMenu(IOFSObject obj)
        {
            if (obj is OFSMenu)
            {
                return (OFSMenu)obj;
            }
            return null;
        }


        private IOFSObject getItem(List<OFSMenu> list, string id, string language)
        {
            if (list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).Any())
            {
                return list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First();
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.MenuChildren.Children.Count > 0){
                        var res = getItem(item.MenuChildren.Children, id, language);
                        if (res != null)
                            return res;
                    }
                }
            }
            return null;
        }

        private IOFSObject getItem(ArrayList list, string id, string language)
        {
            foreach (OFSMenu i in list)
            {
                if (i.Id.ToString() == id && i.Culture.Equals(language, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            foreach (OFSMenu i in list)
            {
                if (i.MenuChildren.Children.Count > 0)
                {
                    var res = getItem(i.MenuChildren.Children, id, language); if (res != null)
                        if (res != null)
                            return res;
                }
            }
            return null;
        }

        private int getNewId(List<OFSMenu> list, string language)
        {
            List<int> plainList = new List<int>();
            Stack<OFSMenu> stack = new Stack<OFSMenu>();

            
                foreach (var item in list)
                {
                    stack.Push(item);
                    while (stack.Count > 0)
                    {
                        OFSMenu taken = stack.Pop();

                        foreach (OFSMenu child in taken.MenuChildren.Children)
                        {
                            stack.Push(child);
                            plainList.Add(child.Id);
                        }

                    }
                }
                return plainList.Max() + 1;
        }

        public List<IOFSObject> Get(string id)
        {
            OFSMenuesXml menu = new OFSMenuesXml(Path);
            return menu.GetAll<OFSMenu>().Where(a => a.Id.ToString() == id).ToList();
        }

        public List<IOFSObject> Get(ILoadingPolicy loadingPolicy)
        {
            throw new NotImplementedException();
        }

        public List<IOFSObject> GetAll<T>()
        {

            OFSMenuesXml menu = new OFSMenuesXml(Path);
            return menu.GetAll<OFSMenu>();
        }

        public bool Save(IOFSObject item)
        {
            OFSMenu itemAppo = (OFSMenu)Get<OFSMenu>(item.Id.ToString(), item.Culture);
            OFSMenuesXml menu = new OFSMenuesXml(Path);
            var list = menu.GetAll<OFSMenu>().ConvertAll<OFSMenu>(new Converter<IOFSObject,OFSMenu>(ConvertOFSMenu));
            


            if (itemAppo == null)
            {

                itemAppo = (OFSMenu)Get<OFSMenu>(((OFSMenu)item).Parent.ToString(), item.Culture);
                item.Id = getNewId(list, item.Culture);
                setItem(list, ((OFSMenu)item).Parent.ToString(), item.Culture, item, true);
            }
            else
            {

                setItem(list, itemAppo.Id.ToString(), itemAppo.Culture, item, false);
            }

            string fileName = Utils.Util.GetFileName(list.First(), Path);

            DataClasses.OFS.Serialization.Serializator serializator = new OFS.Serialization.Serializator();
            serializator.SerializeObject(fileName, list.First());

            return true;

        }


        private void setItem(List<OFSMenu> list, string id, string language, IOFSObject NewValue, bool IsNewItem)
        {
            if (list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).Any())
            {
                var item = list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First() as IOFSObject;
                if (IsNewItem)
                {
                    ((OFSMenu)item).MenuChildren.Children.Add(NewValue);
                }
                else
                {
                    item = NewValue;
                    list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First().Text = ((OFSMenu)NewValue).Text;
                    list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First().HRef = ((OFSMenu)NewValue).HRef;
                    list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First().Parent = ((OFSMenu)NewValue).Parent;
                    list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First().PageId = ((OFSMenu)NewValue).PageId;
                }
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.MenuChildren.Children.Count > 0)
                        setItem(item.MenuChildren.Children, id, language, NewValue, IsNewItem);
                }
            }
        }

        private void setItem(ArrayList list, string id, string language, IOFSObject NewValue, bool IsNewItem)
        {
            foreach (OFSMenu item in list)
            {
                if (item.Id.ToString() == id && item.Culture.Equals(language, StringComparison.OrdinalIgnoreCase))
                {
                    if (IsNewItem)
                    {
                        ((OFSMenu)item).MenuChildren.Children.Add(NewValue);
                    }
                    else
                    {
                        item.Text = ((OFSMenu)NewValue).Text;
                        item.HRef = ((OFSMenu)NewValue).HRef;
                        item.Parent = ((OFSMenu)NewValue).Parent;
                        item.PageId = ((OFSMenu)NewValue).PageId;
                        return;
                    }
                }
            }
            foreach (OFSMenu i in list)
            {
                if (i.MenuChildren.Children.Count > 0)
                    setItem(i.MenuChildren.Children, id, language, NewValue, IsNewItem);
            }
        }

        public bool Delete<T>(IOFSObject item)
        {
            OFSMenu itemAppo = (OFSMenu)Get<OFSMenu>(item.Id.ToString(), item.Culture);
            OFSMenuesXml menu = new OFSMenuesXml(Path);
            var list = menu.GetAll<OFSMenu>().ConvertAll<OFSMenu>(new Converter<IOFSObject, OFSMenu>(ConvertOFSMenu));

            deleteItem(list, itemAppo.Id.ToString(), itemAppo.Culture, item, false);
            string fileName = Utils.Util.GetFileName(list.First(), Path);

            DataClasses.OFS.Serialization.Serializator serializator = new OFS.Serialization.Serializator();
            serializator.SerializeObject(fileName, list.First());
            return true;
        }

        private void deleteItem(List<OFSMenu> list, string id, string language, IOFSObject NewValue, bool IsNewItem)
        {
            if (list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).Any())
            {
                var item = list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First() as IOFSObject;
               
                    item = NewValue;
                    list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First().Deleted = ((OFSMenu)NewValue).Deleted;
                    list.Where(a => a.Id.ToString() == id && a.Culture.Equals(language, StringComparison.OrdinalIgnoreCase)).First().DateDeleted = ((OFSMenu)NewValue).DateDeleted;
                    
                
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.MenuChildren.Children.Count > 0)
                        deleteItem(item.MenuChildren.Children, id, language, NewValue, IsNewItem);
                }
            }
        }

        private void deleteItem(ArrayList list, string id, string language, IOFSObject NewValue, bool IsNewItem)
        {
            foreach (OFSMenu item in list)
            {
                if (item.Id.ToString() == id && item.Culture.Equals(language, StringComparison.OrdinalIgnoreCase))
                {
                    
                        item.Deleted = true;
                        item.DateDeleted = DateTime.Now;
                        return;
                    
                }
            }
            foreach (OFSMenu i in list)
            {
                if (i.MenuChildren.Children.Count > 0)
                    deleteItem(i.MenuChildren.Children, id, language, NewValue, IsNewItem);
            }
        }

        public List<IOFSObject> Items
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IOFSObject DependantIOFSPagesObject
        {
            get { throw new NotImplementedException(); }
        }


        public bool Delete(IOFSObject item)
        {
            throw new NotImplementedException();
        }
    }
}
