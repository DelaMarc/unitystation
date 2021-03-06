﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Text;
using Newtonsoft.Json;


public class BookshelfNetMessage : ServerMessage
{
	public static short MessageType = (short)MessageTypes.BookshelfNetMessage;
	public VariableViewerNetworking.NetFriendlyBookShelfView data;

	public override IEnumerator Process()
	{//JsonConvert.DeserializeObject<VariableViewerNetworking.NetFriendlyBookShelfView>()
		UIManager.Instance.BookshelfViewer.BookShelfView  = data;
		UIManager.Instance.BookshelfViewer.ValueSetUp();
		return null;
	}

	public static BookshelfNetMessage Send(Librarian.BookShelf _BookShelf)
	{
		BookshelfNetMessage msg = new BookshelfNetMessage(); 
		msg.data = VariableViewerNetworking.ProcessBookShelf(_BookShelf);

		msg.SendToAll();
		return msg;
	}
}
