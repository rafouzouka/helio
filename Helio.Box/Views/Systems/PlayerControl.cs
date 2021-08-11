﻿using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Box.Views.Events;
using Helio.Core;
using Helio.Events;
using Helio.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Helio.Box.Systems
{
    public class PlayerControl : ISystem
    {
        private Entity _player;
        
        public void Init()
        {
            EventManager.Instance.AddListener(KeyboardPress, typeof(KeyboardPress));
            EventManager.Instance.AddListener(RegisterPlayerOnCreation, typeof(EntityCreated));
        }

        public void KeyboardPress(Event ev)
        {
            KeyboardPress e = (KeyboardPress)ev;

            switch (e.key)
            {
                case KeyboardKeys.D:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Right));
                    break;

                case KeyboardKeys.Q:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Left));
                    break;

                case KeyboardKeys.Z:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Up));
                    break;

                case KeyboardKeys.S:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Down));
                    break;

                default:
                    break;
            }
        }

        public void LoadContent(ContentManager contentManager)
        {
        }

        public void RegisterPlayerOnCreation(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            if (e.type == EntityType.Player)
            {
                _player = e.id;
            }
        }

        public void Start()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
