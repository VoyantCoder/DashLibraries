// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using DashFramework.DashResources;
using DashFramework.ControlTools;
using DashFramework.Runnables;
using DashFramework.Erroring;
using DashFramework.Sorters;
using DashFramework.Data;


namespace DashFramework
{
    namespace Systems
    {
	public enum REGISTRY_ROOTS
	{
	    CLASSES_ROOT, CURRENT_USER,
	    LOCAL_MACHINE, USERS, CURRENT_CONFIG,
	    PERFORMANCE_DATA
	}

	// Change strings to object.s

	public class EasyRegistry
	{
	    // Summary:
	    //	Export registry values to the given file.  Will be created if it does not exist.
	    public bool BackupSubKeyTree(REGISTRY_ROOTS Root, string Node, string FilePath, bool CreateIfNotExist = true)
	    {
		try
		{
		    if (!SubKeyExists(Root, Node))
		    {
			return false;
		    }

		    else if (!File.Exists(FilePath))
		    {
			if (!CreateIfNotExist)
			{
			    return false;
			}
		    }

		    using (RegistryKey Key = User.OpenSubKey(Node))
		    {
			if (Key == null)
			{
			    return false;
			}

			List<string> BackupData = new List<string>();
			string[] Names = Key.GetValueNames();

			for (int r = Names.Length, k = 0; k < r; k += 1)
			{
			    string Value = Key.GetValue(Names[k], "nil").ToString();

			}
			
			File.WriteAllLines(FilePath, BackupData);
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }


	    // Summary:
	    //	For updating the user manually.  SetRoot(...) is more suitable.
	    public RegistryKey User = Registry.CurrentUser;

	    public bool UpdateUser(RegistryKey User)
	    {
		try
		{
		    if (User != null)
		    {
			this.User = User;
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }
	    public void SetRootLocation(REGISTRY_ROOTS Root)
	    {
		try
		{
		    void Change(RegistryKey ROOT) => User = ROOT;

		    switch (Root)
		    {
			case REGISTRY_ROOTS.PERFORMANCE_DATA: Change(Registry.PerformanceData); break;
			case REGISTRY_ROOTS.CURRENT_CONFIG: Change(Registry.CurrentConfig); break;
			case REGISTRY_ROOTS.LOCAL_MACHINE: Change(Registry.LocalMachine); break;
			case REGISTRY_ROOTS.CLASSES_ROOT: Change(Registry.ClassesRoot); break;
			case REGISTRY_ROOTS.CURRENT_USER: Change(Registry.CurrentUser); break;
			case REGISTRY_ROOTS.USERS: Change(Registry.Users); break;
		    }
		}

		catch
		{
		    throw;
		}
	    }


	    // Summary:
	    //	Verify the existence of the given sub key(s).
	    public bool SubKeyExists(REGISTRY_ROOTS Root, string Node)
	    {
		try
		{
		    using (RegistryKey Key = User.OpenSubKey(Node))
		    {
			return (Key != null);
		    }
		}

		catch
		{
		    return false;
		}
	    }
	    public IEnumerable<bool> SubKeyExists(REGISTRY_ROOTS Root, params string[] Nodes)
	    {
		foreach (string Node in Nodes)
		{
		    yield return SubKeyExists(Root, Node);
		}
	    }


	    // Summary:
	    //	Insert values under the given sub key(s).
	    public bool InsertValue(RegistryKey Key, string EntryName, object Value)
	    {
		try
		{
		    Key.SetValue(EntryName, Value);
		    return (Key.GetValue(EntryName) != null);
		}

		catch
		{
		    throw;
		}
	    }
	    public IEnumerable<bool> InsertValue(RegistryKey Key, params (string, object)[] Pairs)
	    {
		foreach ((string, object) Pair in Pairs)
		{
		    yield return InsertValue(Key, Pair.Item1, Pair.Item2);
		}
	    }
	    public IEnumerable<bool> InsertValues(RegistryKey Key, params (string, object)[] Pairs)
	    {
		return InsertValue(Key, Pairs);
	    }


	    // Summary:
	    //	Remove the given value(s).
	    public bool RemoveValue(REGISTRY_ROOTS Root, string Node, string Name)
	    {
		try
		{
		    using (RegistryKey Key = User.OpenSubKey(Node, true))
		    {
			if (Key == null)
			{
			    return false;
			}

			Key.DeleteValue(Name, true);
		    }

		    return true;
		}

		catch
		{
		    return false;
		}
	    }
	    public IEnumerable<bool> RemoveValue(REGISTRY_ROOTS Root, string Node, params string[] Names)
	    {
		foreach (string Name in Names)
		{
		    yield return RemoveValue(Root, Node, Name);
		}
	    }
	    public IEnumerable<bool> RemoveValues(REGISTRY_ROOTS Root, string Node, params string[] Names)
	    {
		return RemoveValue(Root, Node, Names);
	    }


	    // Summary:
	    //	Create the given sub key(s) and get the Key.
	    public RegistryKey CreateSubKey(REGISTRY_ROOTS Root, string Node)
	    {
		try
		{
		    SetRootLocation(Root);
		    return User.CreateSubKey($"{Node}");
		}

		catch
		{
		    throw;
		}
	    }
	    public IEnumerable<RegistryKey> CreateSubKeys(REGISTRY_ROOTS Root, params string[] Nodes)
	    {
		foreach (string Node in Nodes)
		{
		    yield return CreateSubKey(Root, Node);
		}
	    }
	    public RegistryKey CreateSubKey(REGISTRY_ROOTS Root, string Node, params (string, object)[] Pairs)
	    {
		try
		{
		    RegistryKey Key = CreateSubKey(Root, Node);
		    InsertValues(Key, Pairs);
		    return Key;
		}

		catch
		{
		    throw;
		}
	    }


	    // Summary:
	    //	Create the given sub key(s) without getting the Key.
	    public bool ExCreateSubKey(REGISTRY_ROOTS Root, string Node)
	    {
		try
		{
		    using (RegistryKey Key = CreateSubKey(Root, Node))
		    {
			return SubKeyExists(Root, Node);
		    }
		}

		catch
		{
		    throw;
		}
	    }
	    public IEnumerable<bool> ExCreateSubKeys(REGISTRY_ROOTS Root, params string[] Nodes)
	    {
		for (int k = 0; k < Nodes.Length; k += 1)
		{
		    yield return ExCreateSubKey(Root, Nodes[k]);
		}
	    }
	    public IEnumerable<bool> ExCreateSubKey(REGISTRY_ROOTS Root, string Node, params (string, object)[] Pairs)
	    {
		using (RegistryKey Key = CreateSubKey(Root, Node))
		{
		    return InsertValues(Key, Pairs);
		}
	    }


	    // Summary:
	    //	Remove the given sub key(s).
	    public bool RemoveSubKey(REGISTRY_ROOTS Root, string Node)
	    {
	        User.DeleteSubKey(Node, false);
	        return (!SubKeyExists(Root, Node));
	    }
	    public IEnumerable<bool> RemoveSubKey(REGISTRY_ROOTS Root, params string[] Nodes)
	    {
		foreach (string Node in Nodes)
		{
		    User.DeleteSubKey(Node, false);
		    yield return (!SubKeyExists(Root, Node));
		}
	    }
	    public IEnumerable<bool> RemoveSubKeys(REGISTRY_ROOTS Root, params string[] Nodes)
	    {
		return RemoveSubKey(Root, Nodes);
	    }


	    // Summary:
	    //	Rename the given sub key(s).
	    public bool RenameSubKey(REGISTRY_ROOTS Root, string Node1, string Node2)
	    {
		try
		{
		    List<object> Values = new List<object>();
		    List<string> Names = new List<string>();

		    using (RegistryKey Key = User.OpenSubKey(Node1))
		    {
			Names.AddRange(Key.GetValueNames());
			
			foreach (string Name in Names)
			{
			    Values.Add(Key.GetValue(Name, null));
			}
		    }

		    if (!RemoveSubKey(Root, Node1))
		    {
			return false;
		    }

		    else if (Values.Count < 1 || Names.Count < 1)
		    {
			return false;
		    }

		    using (RegistryKey Key = User.OpenSubKey(Node2, true))
		    {
			for (int i = 0; i < Values.Count; i += 1)
			{
			    InsertValue(Key, (Names[i], Values[i]));
			}
		    }

		    return SubKeyExists(Root, Node2);
		}

		catch
		{
		    return false;
		}
	    }
	    public IEnumerable<bool> RenameSubKey(REGISTRY_ROOTS Root, params (string, string)[] Nodes)
	    {
		foreach ((string, string) Node in Nodes)
		{
		    yield return RenameSubKey(Root, Node.Item1, Node.Item2);
		}
	    }
	    public IEnumerable<bool> RenameSubKeys(REGISTRY_ROOTS Root, params (string, string)[] Nodes)
	    {
	        return RenameSubKey(Root, Nodes);
	    }
	}
    }
}
