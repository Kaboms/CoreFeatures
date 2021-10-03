using System.Collections.Generic;
using UnityEngine.Events;
using CoreFeatures.Singleton;

namespace CoreFeatures.MessageBus
{
	public class MessageBus : Singleton<MessageBus>
	{
		private Dictionary<string, UnityEvent<Message>> _subsribers;

		//--------------------------------------------------------------------------

		private void Awake()
		{
			_subsribers = new Dictionary<string, UnityEvent<Message>>();
		}
		//--------------------------------------------------------------------------

		public void Subsribe(string messageName, UnityAction<Message> messageDelegate)
		{
			if (!_subsribers.ContainsKey(messageName))
			{
				_subsribers[messageName] = new UnityEvent<Message>();
			}

			_subsribers[messageName].AddListener(messageDelegate);
		}
		//--------------------------------------------------------------------------

		public void Unsubsribe(string messageName, UnityAction<Message> messageDelegate)
		{
			if (!_subsribers.ContainsKey(messageName))
			{
				print($"{messageName} not found!");
				return;
			}

			_subsribers[messageName].RemoveListener(messageDelegate);
		}
		//--------------------------------------------------------------------------

		public void Invoke(string messageName, Message message)
		{
			if (!_subsribers.ContainsKey(messageName))
			{
				print($"{messageName} not found!");
				return;
			}

			_subsribers[messageName].Invoke(message);
		}
		//--------------------------------------------------------------------------
	}
}