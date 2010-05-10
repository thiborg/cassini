/* **********************************************************************************
 *
 * Copyright (c) Tanzim Saqib. All rights reserved.
 *
 * This source code is subject to terms and conditions of the Microsoft Public
 * License (Ms-PL). A copy of the license can be found in the license.htm file
 * included in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * For continued development:   http://www.TanzimSaqib.com
 * Source:                      http://cassini.googlecode.com/
 * License information:         http://www.opensource.org/licenses/ms-pl.html
 *
 * **********************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cassini
{
    public class EventBrokerEventArgs : EventArgs
    {
        public dynamic Argument { get; set; }

        public EventBrokerEventArgs()
        {
        }

        public EventBrokerEventArgs(dynamic argument)
        {
            Argument = argument;
        }
    }

    public class EventBroker
    {
        public static event EventHandler SubscriptionAdded;
        public static event EventHandler SubscriptionRemoved;

        private static volatile EventBroker _Instance;
        private static object _SyncRoot = new Object();
        private static Dictionary<string, List<Action<dynamic, dynamic>>> _Subscriptions;

        public EventBroker()
        {
            
        }

        public static EventBroker Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new EventBroker();
                            _Subscriptions = new Dictionary<string, List<Action<dynamic, dynamic>>>();
                        }
                    }
                }

                return _Instance;
            }
        }

        private static Dictionary<string, List<Action<dynamic, dynamic>>> Subscriptions
        {
            get { return EventBroker._Subscriptions; }
            set
            {
                lock (_SyncRoot)
                {
                    EventBroker._Subscriptions = value;
                }
            }
        }

        public static void Subscribe(string key, Action<dynamic, dynamic> action)
        {
            List<Action<dynamic, dynamic>> actions = null;

            if (Subscriptions == null)
                Subscriptions = new Dictionary<string, List<Action<dynamic, dynamic>>>();

            if (Subscriptions.ContainsKey(key))
            {
                actions = _Subscriptions[key];
            }
            else
            {
                actions = new List<Action<dynamic, dynamic>>();
                Subscriptions.Add(key, actions);
            }

            actions.Add(action);
            OnSubscriptionAdded(new EventArgs());
        }

        public static void Unsubscribe(string key, Action<dynamic, dynamic> action)
        {
            if (Subscriptions.ContainsKey(key))
            {
                if (Subscriptions[key].Contains(action))
                {
                    Subscriptions[key].Remove(action);
                    OnSubscriptionRemoved(new EventArgs());
                }

                if (Subscriptions[key].Count == 0)
                    Subscriptions.Remove(key);
            }
        }

        private static void OnSubscriptionAdded(EventArgs e)
        {
            if (SubscriptionAdded != null)
                SubscriptionAdded(_Instance, e);
        }

        private static void OnSubscriptionRemoved(EventArgs e)
        {
            if (SubscriptionRemoved != null)
                SubscriptionRemoved(_Instance, e);
        }

        public static void Raise(string key, object sender, EventArgs e)
        {
            if (Subscriptions.ContainsKey(key))
            {
                for (int i = 0; i < Subscriptions[key].Count; i++)
                {
                    Invoke(key, Subscriptions[key][i], sender, e);

                    if (!Subscriptions.ContainsKey(key))
                        break;
                }
            }
        }

        private static void Invoke(string key, Action<dynamic, dynamic> action, object sender, EventArgs e)
        {
            if (action.Method != null)
            {
                if (action.Target is Control)
                {
                    var control = (Control)action.Target;

                    if (control.IsDisposed)
                    {
                        Unsubscribe(key, action);
                        return;
                    }
                }

                action.DynamicInvoke(sender, e);
            }
        }
    }
}
