using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using EmptyKeys.UserInterface.Generated;
using EmptyKeys.UserInterface.Debug;
using EmptyKeysTestCCSP.ViewModels;
using EmptyKeys.UserInterface.Media;
using EmptyKeys.UserInterface;
using EmptyKeys.UserInterface.Media.Effects;
using Microsoft.Xna.Framework.Content;

namespace EmptyKeysTestCCSP
{
    public class IntroLayer : CCLayerColor
    {
        //EmptyKeys elements
        Root root;
        DebugViewModel debug;
        private float elapsedGameTime;
        private CCCustomCommand renderCommand;
        // Define a label variable

        public IntroLayer() : base(CCColor4B.Blue)
        {
            Color = new CCColor3B(CCColor4B.Red);
            Opacity = 0;
            renderCommand = new CCCustomCommand(RenderUI);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;
            var content = GameView.ContentManager;
            int w = int.Parse(bounds.Size.Width.ToString());
            int h = int.Parse(bounds.Size.Height.ToString());
            root = new Root(w, h);  //LJO : Bug HERE
            debug = new DebugViewModel(root);
            root.DataContext = new RootViewModel();

            SoundManager.Instance.LoadSounds(content, "sounds");
            ImageManager.Instance.LoadImages(content);
            FontManager.Instance.LoadFonts(content, "fonts");
            EffectManager.Instance.LoadEffects(content);

            Schedule(UpdateUI);

            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        private void UpdateUI(float frameTimeInSeconds)
        {
            elapsedGameTime = frameTimeInSeconds * 1000;
            debug.Update();
            root.UpdateInput(elapsedGameTime);
            root.UpdateLayout(elapsedGameTime);

        }

        protected override void VisitRenderer(ref CCAffineTransform worldTransform)
        {
            base.VisitRenderer(ref worldTransform);

            Renderer.AddCommand(renderCommand);
        }

        private void RenderUI()
        {
            root.Draw(elapsedGameTime);
            debug.Draw();
        }


        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }
    }
}

