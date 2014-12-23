using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using GeoScene.Globe;
using GeoScene.Data;
using GeoScene.Engine;
 
using System.Management;
using System.Runtime.InteropServices;
using System.Xml;
using WorldGIS.Forms;
using System.Collections;

namespace WorldGIS
{
    public partial class MainFrm : DevComponents.DotNetBar.Office2007Form
    {
        GeoScene.Globe.GSOGlobeControl globeControl1;
        GeoScene.Engine.GSODataManager dataMananger1;
        String m_strWorkSpacePath = "";
        String m_strFormTitle = "LSPipeline";
       
        GSOBalloon featureTooltip;
        GSOBalloon infoBalloon;
        GSOBalloonEx balloonEx;
        int m_nWaterPipeDemoTick = 0;

        //记录沿线飞行设置
        int m_nFlyMode = 2;
        double m_dFlyAboveLine = 1;
        double m_dFlyAlongLineSpeed = 50;
        double m_dFlyAlongLineRotateSpeed = 50;

        // 挖坑设置
        Double m_dDigPitValue = 3;
        Double m_dDigPitWidthAlongLine = 6;
        Boolean m_bDigPitByDepth = true;

        TreeNode dataManagerNode = null;
        TreeNode myPlaceNode = null;
        TreeNode layerManagerNode = null;
        TreeNode terrainManagerNode = null;

        bool m_bFullScreen = false;
        Rectangle m_rcOld=new Rectangle(0,0,0,0);

        //管线间距分析
        private GSOFeature m_DisAnalysisFirstFeature;
        private GSOFeature m_DisAnalysisSecondFeature;
        private GSOFeature disFeature = new GSOFeature();
        private GSOFeature featureDis = new GSOFeature();
        GSOLayer layerTemp;

        public MainFrm()
        {  
            InitializeComponent();

            globeControl1 = new GeoScene.Globe.GSOGlobeControl();
            dataMananger1 = new GeoScene.Engine.GSODataManager();

            panelGlobeControl.Controls.Add(globeControl1);
            globeControl1.Dock = DockStyle.Fill;

            layerTree.ImageList = treeImageList;
            layerTree.Dock = DockStyle.Fill;

            controlContainerItem2.Control = panelFind;
            panelFind.Dock = DockStyle.Fill;
                                
            treeFind.ImageList = treeImageList;

            featureTooltip = new GSOBalloon(globeControl1.Handle);
            featureTooltip.CacheFilePath = Application.StartupPath + "/GeoScene/Globe/Temp";
            featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CX, 0);
            featureTooltip.SetSize(EnumSizeIndex.ROUNDED_CY, 0);
            featureTooltip.SetSize(EnumSizeIndex.MARGIN_CX, 3);
            featureTooltip.SetSize(EnumSizeIndex.MARGIN_CY, 3);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_HEIGHT, 0);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_WIDTH, 0);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_MARGIN, 0);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_OFFSET_CX, 1);
            featureTooltip.SetSize(EnumSizeIndex.ANCHOR_OFFSET_CY, -1);
            featureTooltip.SetDirection(EnumToolTipDirection.TD_BOTTOMEDGE_LEFT);
            featureTooltip.EscapeSequencesEnabled = true;
            featureTooltip.HyperlinkEnabled = true;
            featureTooltip.Opaque = 30; //30;
            featureTooltip.MaxWidth = 300;            
            featureTooltip.SetShadow(0, 0, 50, true, 0, 0);

            infoBalloon = new GSOBalloon(globeControl1.Handle);
            infoBalloon.SetColorBkType(EnumBkColorType.SILVER);
            infoBalloon.SetEffectBk(EnumBkEffect.HBUMP, 0);
            infoBalloon.SetBorder(Color.FromArgb(255, 171, 171, 171), 1, 1);
            infoBalloon.SetSize(EnumSizeIndex.ROUNDED_CX, 5);
            infoBalloon.SetSize(EnumSizeIndex.ROUNDED_CY, 5);
            infoBalloon.SetSize(EnumSizeIndex.ANCHOR_HEIGHT, 20);
            infoBalloon.SetSize(EnumSizeIndex.ANCHOR_WIDTH, 12);
            infoBalloon.SetShadow(3, 3, 50, true, 0, 0);
            infoBalloon.MaxWidth = 300;
            infoBalloon.CloseButtonVisible = true;

            balloonEx = new GSOBalloonEx(globeControl1.Handle);
            balloonEx.SetSize(EnumSizeIndexEx.ANCHOR_WIDTH, 30);
            balloonEx.SetColorBkType(EnumBkColorTypeEx.SILVER);
            balloonEx.SetEffectBk(EnumBkEffectEx.OUTRANGE, 10);
            balloonEx.CacheFilePath = Application.StartupPath + "/GeoScene/Globe/Temp";
        }

        //工具栏按钮
        GSOHudButton navigate = null;
        GSOHudButton select = null;
        GSOHudButton line = null;
        GSOHudButton measure = null;
        GSOHudButton marker = null;
        GSOHudButton model = null;
        GSOHudButton move = null;
        GSOHudButton rotate = null;
        GSOHudButton elevate = null;
       
        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = m_strFormTitle;            

            globeControl1.MouseDoubleClick += new MouseEventHandler(sceneControl1_MouseDoubleClick);
            globeControl1.MouseMove += new MouseEventHandler(sceneControl1_MouseMove);            
            globeControl1.MouseClick += new MouseEventHandler(sceneControl1_MouseClick);
            globeControl1.MouseDown += new MouseEventHandler(sceneControl1_MouseDown);
            globeControl1.MouseUp += new MouseEventHandler(sceneControl1_MouseUp);

            globeControl1.AfterLayerAddEvent += new AfterLayerAddEventHandler(globeControl1_AfterLayerAddEvent);  
            globeControl1.FeatureMouseClickEvent += new FeatureMouseClickEventHandler(sceneControl1_FeatureMouseClick);            
            globeControl1.FeatureMouseHoverEvent += new FeatureMouseHoverEventHandler(sceneControl1_FeatureMouseHover);
            globeControl1.CameraBeginMoveEvent += new CameraBeginMoveEventHandler(sceneControl1_CameraBeginMove);
            globeControl1.DrawAddFeatureEvent += new DrawAddFeatureEventHandler(sceneControl1_DrawAddFeature);
            globeControl1.AfterKeyDownDeleteFeatureEvent += new AfterKeyDownDeleteFeatureEventHandler(sceneControl1_AfterKeyDownDeleteFeatureEvent);
            globeControl1.TrackPolylineEndEvent += new TrackPolylineEndEventHandler(sceneControl1_TrackPolylineAnalysisEndEvent);
            globeControl1.TrackPolygonEndEvent += new TrackPolygonEndEventHandler(sceneControl1_TrackPolygonAnalysisEndEvent);
            globeControl1.AfterNetLayerAddEvent += new AfterNetLayerAddEventHandler(globeControl1_AfterNetLayerAddEvent);
            globeControl1.KeyDown += new KeyEventHandler(globeControl1_KeyDown);

            //地面透明背景色
            globeControl1.Globe.UserBackgroundColorValid = true;
            globeControl1.Globe.UserBackgroundColor = Color.White;

            //globeControl1.Globe.OverviewControl.Visible = false;//鹰眼
            globeControl1.Globe.ScalerControl.Visible = false;  //比例尺    

            //自定义工具栏
            GSOTextStyle textStyle = new GSOTextStyle();
            textStyle.ForeColor = Color.White;            
            textStyle.FontSize = 9;
         
            navigate = new GSOHudButton();
            navigate.Name = "navigate";
            navigate.TextAlign = EnumAlign.BottomCenter;
            navigate.TextStyle = textStyle;            
            navigate.TextOffset = new GSOPoint2d(0, -10);
            navigate.SetImage(Application.StartupPath + "/Resource/images/hand36.png");
            navigate.MinOpaque = 1;
            navigate.MaxOpaque = 1;
            navigate.Align = EnumAlign.BottomCenter;
            navigate.SetOffset(-270, 30);            
            globeControl1.Globe.AddHudControl(navigate);  
            
            select = new GSOHudButton();
            select.Name = "select";
            select.TextAlign = EnumAlign.BottomCenter;
            select.TextStyle = textStyle;
            select.TextOffset = new GSOPoint2d(0, -10);
            select.SetImage(Application.StartupPath + "/Resource/images/select36.png");
            select.MinOpaque = 1;
            select.MaxOpaque = 1;
            select.Align = EnumAlign.BottomCenter;
            select.SetOffset(-210, 30);
            globeControl1.Globe.AddHudControl(select);          

            move = new GSOHudButton();
            move.Name = "move";
            move.TextAlign = EnumAlign.BottomCenter;
            move.TextStyle = textStyle;
            move.TextOffset = new GSOPoint2d(0, -10);
            move.SetImage(Application.StartupPath + "/Resource/images/move36.png");
            move.MinOpaque = 1;
            move.MaxOpaque = 1;
            move.Align = EnumAlign.BottomCenter;
            move.SetOffset(-150, 30);
            globeControl1.Globe.AddHudControl(move);  

            rotate = new GSOHudButton();
            rotate.Name = "rotate";
            rotate.TextAlign = EnumAlign.BottomCenter;
            rotate.TextStyle = textStyle;
            rotate.TextOffset = new GSOPoint2d(0, -10);
            rotate.SetImage(Application.StartupPath + "/Resource/images/rotate36.png");
            rotate.MinOpaque = 1;
            rotate.MaxOpaque = 1;
            rotate.Align = EnumAlign.BottomCenter;
            rotate.SetOffset(-90, 30);
            globeControl1.Globe.AddHudControl(rotate);          

            elevate = new GSOHudButton();
            elevate.Name = "elevate";
            elevate.TextAlign = EnumAlign.BottomCenter;
            elevate.TextStyle = textStyle;
            elevate.TextOffset = new GSOPoint2d(0, -10);
            elevate.SetImage(Application.StartupPath + "/Resource/images/elevate36.png");
            elevate.MinOpaque = 1;
            elevate.MaxOpaque = 1;
            elevate.Align = EnumAlign.BottomCenter;
            elevate.SetOffset(-30, 30);
            globeControl1.Globe.AddHudControl(elevate);           

            line = new GSOHudButton();
            line.Name = "line";
            line.TextAlign = EnumAlign.BottomCenter;
            line.TextStyle = textStyle;
            line.TextOffset = new GSOPoint2d(0, -10);
            line.SetImage(Application.StartupPath + "/Resource/images/line36.png");
            line.MinOpaque = 1;
            line.MaxOpaque = 1;
            line.Align = EnumAlign.BottomCenter;
            line.SetOffset(30, 30);
            globeControl1.Globe.AddHudControl(line);          
           
            measure = new GSOHudButton();
            measure.Name = "measure";
            measure.TextAlign = EnumAlign.BottomCenter;
            measure.TextStyle = textStyle;
            measure.TextOffset = new GSOPoint2d(0, -10);
            measure.SetImage(Application.StartupPath + "/Resource/images/measure36.png");
            measure.MinOpaque = 1;
            measure.MaxOpaque = 1;
            measure.Align = EnumAlign.BottomCenter;
            measure.SetOffset(90, 30);
            globeControl1.Globe.AddHudControl(measure);           
           
            marker = new GSOHudButton();
            marker.Name = "marker";
            marker.TextAlign = EnumAlign.BottomCenter;
            marker.TextStyle = textStyle;
            marker.TextOffset = new GSOPoint2d(0, -10);
            marker.SetImage(Application.StartupPath + "/Resource/images/marker36.png");
            marker.MinOpaque = 1;
            marker.MaxOpaque = 1;
            marker.Align = EnumAlign.BottomCenter;
            marker.SetOffset(150, 30);
            globeControl1.Globe.AddHudControl(marker);           
            
            model = new GSOHudButton();
            model.Name = "model";
            model.TextAlign = EnumAlign.BottomCenter;
            model.TextStyle = textStyle;
            model.TextOffset = new GSOPoint2d(0, -10);
            model.SetImage(Application.StartupPath + "/Resource/images/model36.png");
            model.MinOpaque = 1;
            model.MaxOpaque = 1;
            model.Align = EnumAlign.BottomCenter;
            model.SetOffset(210, 30);
            globeControl1.Globe.AddHudControl(model);
           
            //给工具栏绑定事件
            globeControl1.HudControlMouseDownEvent  += new HudControlMouseDownEventHandler(globeControl1_HudControlMouseDownEvent);
            globeControl1.HudControlMouseIntoEvent += new HudControlMouseIntoEventHandler(globeControl1_HudControlMouseIntoEvent);
            globeControl1.HudControlMouseOutEvent += new HudControlMouseOutEventHandler(globeControl1_HudControlMouseOutEvent);
           
            globeControl1.Globe.StatusBar.Visible = true;            
            globeControl1.Globe.LatLonGrid.Visible = GridMenue.Checked = false;
            MarbleSurfaceMenuItem.Checked = globeControl1.Globe.MarbleVisible;
            underGroundLockedMenuItem.Checked = globeControl1.Globe.IsUnderGroundLocked;

            globeControl1.Globe.UnderGroundFloor.Visible = false;
            globeControl1.Globe.Object2DMouseOverEnable = true;
            地下网格ToolStripMenuItem.Checked = false;
            MenuItem2DObjMouseOverEnable.Checked = true;
           
            AtmospherMenue.Checked = true;
            StatusMenu.Checked = true;
            NavigationControlMenu.Checked = true;          
            MainToolBarShowMenu.Checked = true;

            dataManagerNode = new TreeNode();
            dataManagerNode.ImageIndex = 0;
            dataManagerNode.SelectedImageIndex = 0;
            dataManagerNode.Checked = true;
            dataManagerNode.Text = "数据管理";
            layerTree.Nodes.Add(dataManagerNode);
            
            myPlaceNode = new TreeNode();
            myPlaceNode.ImageIndex = 0;            
            myPlaceNode.SelectedImageIndex = 0;
            myPlaceNode.Checked = true;
            myPlaceNode.Tag = globeControl1.Globe.MemoryLayer;
            myPlaceNode.Text = "我的地标";
            myPlaceNode.NodeFont = new Font(layerTree.Font ,FontStyle.Bold);           
            layerTree.Nodes.Add(myPlaceNode);

            layerManagerNode = new TreeNode();
            layerManagerNode.ImageIndex = 0;
            layerManagerNode.SelectedImageIndex = 0;
            layerManagerNode.Checked = true;
            layerManagerNode.Text = "图层管理";            
            layerTree.Nodes.Add(layerManagerNode);

            terrainManagerNode = new TreeNode();
            terrainManagerNode.ImageIndex = 0;
            terrainManagerNode.SelectedImageIndex = 0;
            terrainManagerNode.Checked = true;
            terrainManagerNode.Text = "地形管理";
            layerTree.Nodes.Add(terrainManagerNode);

            ReadKmlToMemoryLayer(Path.GetDirectoryName(Application.ExecutablePath) + "/MyPlace.kml");
            RefreshDataTree();

            globeControl1.Globe.FlyAlongLineSpeed = m_dFlyAlongLineSpeed;
            globeControl1.Globe.FlyAlongLineRotateSpeed = m_dFlyAlongLineRotateSpeed;
            ActionToolMenuChecked();
           
            //修改状态栏
            globeControl1.Globe.StatusBar.SetTextVisible(EnumStatusBarText.ProCoord, false);           
            globeControl1.Globe.StatusBar.SetTextVisible(EnumStatusBarText.TerrainHeight, false);           
              
            // 加上这句Mouseover、MouseInto、MouseOut才会有反应
            globeControl1.Globe.FeatureMouseOverEnable = true;
            MenuItemMouseOverEventEnable.Checked = true;            

            globeControl1.Globe.FeatureMouseOverHighLight=false;
            EnableMouseOverHighLightMenu.Checked = false;

            CameraNavigationMenu.Checked = true;
            AntiAntialiasingMenuItem.Checked = globeControl1.Globe.Antialiasing;

            globeControl1.Globe.ModelRenderDetail = EnumRenderDetail.Texture;
            ModelTextureMenuItem.Checked = true;

            globeControl1.Globe.HighlightEntityStyle3D.EntityColor = Color.FromArgb(255, 255, 255, 0);         

            // 沿线飞行
            globeControl1.Globe.FlyAlongLineSpeed = 50; //单位：m/s            
            globeControl1.Globe.FlyAlongLineRotateSpeed = 50; // 单位：度/s
            globeControl1.Globe.FlyToPointSpeed = 2 * globeControl1.Globe.FlyToPointSpeed;

            //状态栏的显示内容
            statusStrip1.Items[1].Text = "当前目标图层：" + "我的地标";
        }

        //工具栏事件
        void globeControl1_HudControlMouseDownEvent(object sender, HudControlMouseDownEventArgs e)
        {
            if (e.HudControl != null)
            {
                GSOHudButton button = e.HudControl as GSOHudButton;
                switch (e.HudControl.Name)
                { 
                    case "navigate":
                        globeControl1.Globe.Action = EnumAction3D.ActionNull;                       
                        break;
                    case "select":
                        globeControl1.Globe.Action = EnumAction3D.SelectObject;
                        break;
                    case "move":
                        globeControl1.Globe.Action = EnumAction3D.MoveObject;
                        break;
                    case "rotate":
                        globeControl1.Globe.Action = EnumAction3D.RotateObject;
                        break;
                    case "elevate":
                        globeControl1.Globe.Action = EnumAction3D.ElevateObject;
                        break;                     
                    case "measure":
                        globeControl1.Globe.Action = EnumAction3D.MeasureDistance;
                        break;
                    case "marker":
                        AddPlaceMarkMenu_Click(sender, e);
                        break;
                    case "line":
                        globeControl1.Globe.Action = EnumAction3D.DrawPolyline;
                        break;
                    case "model":
                        AddModelMenu_Click(sender, e);
                        break;                        
                }
                ActionToolMenuChecked();
            }
        }     
        
        void globeControl1_HudControlMouseIntoEvent(object sender, HudControlMouseIntoEventArgs e)
        {
            if (e.HudControl != null)
            {
                GSOHudButton button = e.HudControl as GSOHudButton;               
                switch (e.HudControl.Name)
                {
                    case "navigate":
                        button.SetImage(Application.StartupPath + "/Resource/images/hand48.png");
                        button.Text = " 浏览对象";                        
                        break;
                    case "select":
                        button.SetImage(Application.StartupPath + "/Resource/images/select48.png");
                        button.Text = " 选中对象";                        
                        break;
                    case "move":
                        button.SetImage(Application.StartupPath + "/Resource/images/move48.png");
                        button.Text = " 平移对象";
                        break;
                    case "rotate":
                        button.SetImage(Application.StartupPath + "/Resource/images/rotate48.png");
                        button.Text = " 旋转对象";
                        break;
                    case "elevate":
                        button.SetImage(Application.StartupPath + "/Resource/images/elevate48.png");
                        button.Text = " 升降对象";
                        break;
                    case "measure":
                        button.SetImage(Application.StartupPath + "/Resource/images/measure48.png");
                        button.Text = " 测量距离";                        
                        break;
                    case "marker":
                        button.SetImage(Application.StartupPath + "/Resource/images/marker48.png");
                        button.Text = " 添加标注";                        
                        break;
                    case "line":
                        button.SetImage(Application.StartupPath + "/Resource/images/line48.png");
                        button.Text = " 绘制线";                        
                        break;
                    case "model":
                        button.SetImage(Application.StartupPath + "/Resource/images/model48.png");
                        button.Text = " 添加模型";                        
                        break;
                }
            }
        }
        void globeControl1_HudControlMouseOutEvent(object sender, HudControlMouseOutEventArgs e)
        {
            if (e.HudControl != null)
            {
                GSOHudButton button = e.HudControl as GSOHudButton;
                switch (e.HudControl.Name)
                {
                    case "navigate":
                        button.SetImage(Application.StartupPath + "/Resource/images/hand36.png");
                        button.Text = "";
                        break;
                    case "select":
                        button.SetImage(Application.StartupPath + "/Resource/images/select36.png");
                        button.Text = "";
                        break;
                    case "move":
                        button.SetImage(Application.StartupPath + "/Resource/images/move36.png");
                        button.Text = "";
                        break;
                    case "rotate":
                        button.SetImage(Application.StartupPath + "/Resource/images/rotate36.png");
                        button.Text = "";
                        break;
                    case "elevate":
                        button.SetImage(Application.StartupPath + "/Resource/images/elevate36.png");
                        button.Text = "";
                        break;
                    case "measure":
                        button.SetImage(Application.StartupPath + "/Resource/images/measure36.png");
                        button.Text = "";
                        break;
                    case "marker":
                        button.SetImage(Application.StartupPath + "/Resource/images/marker36.png");
                        button.Text = "";
                        break;
                    case "line":
                        button.SetImage(Application.StartupPath + "/Resource/images/line36.png");
                        button.Text = "";
                        break;
                    case "model":
                        button.SetImage(Application.StartupPath + "/Resource/images/model36.png");
                        button.Text = "";
                        break;
                }
            }
        }

        //调转管线方向的快捷键的事件        
        void globeControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.G)
            {
                ReverseDirection();
            }
        }

        void globeControl1_AfterLayerAddEvent(object sender, AfterLayerAddEventArgs e)
        {
            if (e.Layer.Name != null && e.Layer.Name.Length > 5)
            {
                if (e.Layer.Name.Substring(0,5).Equals("fttp:"))
                {
                    return;
                }
            }            
            if (Path.GetExtension(e.Layer.Name).ToLower().Equals(".kml"))
            {
                AddKmlLayer(e.Layer);
            }
            else
            {
                GSODataset dataset = e.Layer.Dataset;
                CheckDatasetGeoReference(e.Layer.Dataset);
                TreeNode node = new TreeNode();
                node.Tag = e.Layer;
                node.Text = e.Layer.Dataset.Caption;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Checked = e.Layer.Visible;
                // 注意用insert不要用add，因为后加入的图层在上层                
                layerManagerNode.Nodes.Insert(0, node);
            }

            layerManagerNode.Expand();
            terrainManagerNode.Expand();
        }

        private void ActionToolMenuChecked()
        {
            平面距离量算ToolStripMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.MeasureDistance && !globeControl1.Globe.DistanceRuler.SpaceMeasure);
            距地面高度量算ToolStripMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.MeasureHeight && !globeControl1.Globe.HeightRuler.SpaceMeasure);
            平面面积量算ToolStripMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.MeasureArea && !globeControl1.Globe.AreaRuler.SpaceMeasure);
            空间距离量算ToolStripMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.MeasureDistance && globeControl1.Globe.DistanceRuler.SpaceMeasure);
            空间高度量算ToolStripMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.MeasureHeight && globeControl1.Globe.HeightRuler.SpaceMeasure);
            空间面积量算ToolStripMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.MeasureArea && globeControl1.Globe.AreaRuler.SpaceMeasure);
            框选删除ToolStripMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.TrackPolygon);
            横断面分析toolStripMenuItem3.Checked = (globeControl1.Globe.Action == EnumAction3D.TrackPolyline);
                
            SelObjMenu.Checked  = (globeControl1.Globe.Action == EnumAction3D.SelectObject);
            MoveObjMenu.Checked  = (globeControl1.Globe.Action == EnumAction3D.MoveObject);
            ScaleObjMenu.Checked  = (globeControl1.Globe.Action == EnumAction3D.ScaleObject);
            RotateObjMenu.Checked  = (globeControl1.Globe.Action == EnumAction3D.RotateObject);
            ElevateMenu.Checked = (globeControl1.Globe.Action == EnumAction3D.ElevateObject);
            ActionBrowseMenu.Checked = (globeControl1.Globe.Action == EnumAction3D.ActionNull);
            AddLineMenu.Checked  = (globeControl1.Globe.Action == EnumAction3D.DrawPolyline);
            DrawWaterMenuItem.Checked = (globeControl1.Globe.Action == EnumAction3D.DrawWater);
            DrawPolygonMenuItem.Checked  = (globeControl1.Globe.Action == EnumAction3D.DrawPolygon);

            QuickFlyMenu.Checked = (m_nFlyMode == 1);
            MidSpeedFlyMenu.Checked = (m_nFlyMode == 2);
            SlowFlyMenu.Checked = (m_nFlyMode == 3);
            
            SelLevel1MenuItem.Checked=(globeControl1.Globe.SelLevel==0);
            SelLevel2MenuItem.Checked = (globeControl1.Globe.SelLevel == 1);
            SelLevel3MenuItem.Checked = (globeControl1.Globe.SelLevel == 2);
            SetSelLevelMenuItem.Checked = (globeControl1.Globe.SelLevel > 2);

            if (globeControl1.Globe.Action != EnumAction3D.TrackPolyline)
            {
                ProfileAnalysisMenuItem.Checked = false;
                BaselineProfileAnalysisMenuItem.Checked = false;
                LineDigPitMenuItem.Checked = false;
            }

            if (globeControl1.Globe.Action != EnumAction3D.TrackPolygon)
            {
                DigFillAnalysisMenuItem.Checked = false;
                NoSourceFloodSubmergeMenuItem.Checked = false;
                PolygonDigPitMenuItem.Checked = false;
            }
            string currentAction = "";
            switch(globeControl1.Globe.Action)
            {
                case EnumAction3D.ActionNull:
                    currentAction = "浏览对象";
                    break;
                case EnumAction3D.DrawPolygon:
                    currentAction = "绘制面";
                    break;
                case EnumAction3D.DrawPolyline:
                    currentAction = "绘制线";
                    break;
                case EnumAction3D.DrawWater:
                    currentAction = "绘制水面";
                    break;
                case EnumAction3D.ElevateObject:
                    currentAction = "升降对象";
                    break;
                case EnumAction3D.MeasureArea:
                    currentAction = "测量面积";
                    break;
                case EnumAction3D.MeasureDistance:
                    currentAction = "测量距离";
                    break;
                case EnumAction3D.MeasureHeight:
                    currentAction = "测量高度";
                    break;
                case EnumAction3D.MoveObject:
                    currentAction = "平移对象";
                    break;
                case EnumAction3D.RotateObject:
                    currentAction = "旋转对象";
                    break;
                case EnumAction3D.ScaleObject:
                    currentAction = "缩放对象";
                    break;
                case EnumAction3D.SelectObject:
                    currentAction = "选择对象";
                    break;
                case EnumAction3D.TrackPolygon:
                    currentAction = "填挖方分析";
                    break;
                case EnumAction3D.TrackPolyline:
                    currentAction = "剖面分析";
                    break;
                case EnumAction3D.ViewEnvelopeAnalysis:
                    currentAction = "可视包络分析";
                    break;
                case EnumAction3D.ViewshedAnalysis:
                    currentAction = "可视域分析";
                    break;
                case EnumAction3D.VisibilityAnalysis:
                    currentAction = "空间通视分析";
                    break;
                default:
                    break;
            }
            statusStrip1.Items[0].Text = "当前鼠标状态：" + currentAction;
        }
        private void LookSelobjAttribute(GSOLayer layer,GSOFeature feature)
        {
            if (feature != null)
            {
                FrmFeatureInfo dlg = new FrmFeatureInfo(feature,layer,globeControl1);               
                dlg.Show(this);
            }
        }
        private void LookSelobjAttribute(GSOFeature feature)
        {
            if (feature != null)
            {
                FrmFeatureInfo dlg = new FrmFeatureInfo(feature, null, globeControl1);                
               dlg.Show(this);
            }
        }

        private void RefreshDataTree()
        {
            layerTree.Nodes[0].Nodes.Clear();
            Int32 nCount = globeControl1.Globe.DataManager.DataSourceCount;
            Int32 i = 0;
            for (i = 0; i < nCount; i++)
            {               
                GSODataSource dataSpace = globeControl1.Globe.DataManager[i];
                TreeNode node = new TreeNode();
                node.Text = dataSpace.Name;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Checked = true;
                node.Tag = dataSpace;
                Int32 nDatasetCount = dataSpace.DatasetCount;
                for (Int32 j = 0; j < nDatasetCount; j++)
                {
                    GSODataset dataset = dataSpace[j];
                    TreeNode subNode = new TreeNode();
                    subNode.Text = dataset.Name;
                    subNode.ImageIndex = 0;
                    subNode.SelectedImageIndex = 0;
                    subNode.Checked = true;
                    subNode.Tag = dataset;
                    node.Nodes.Add(subNode);
                }
                layerTree.Nodes[0].Nodes.Add(node);
            }
        }

        Boolean CheckDatasetGeoReference(GSODataset dataset)
        {
            Boolean bSuccess=false;
            if (dataset.GeoReferenceType == EnumGeoReferenceType.Flat)
            {
                if (MessageBox.Show("数据没有空间参考信息，请设置空间参考信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    String strPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Coordinate Systems";
                    OpenFileDialog dlg = new OpenFileDialog();
                      
                    dlg.InitialDirectory = strPath;
                    dlg.RestoreDirectory = true;                    

                    dlg.Filter = "投影文件|*.prj||";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        bSuccess=dataset.LoadProjectionFromESRIFile(dlg.FileName);
                    } 
                }
            }
            else
            {
                return true;
            }
            return bSuccess;
        }
        private object AddLayerData(string strDataPath)
        {
            object objRes = null;
            if (Path.GetExtension(strDataPath).ToLower().Equals(".kml"))
            {
                GSOLayer layer = globeControl1.Globe.Layers.Add(strDataPath);
                objRes = layer;
            }
            else if (GSOUtility.IsDatasetSupportTerrain(strDataPath))
            {
                GSOTerrain terrain = globeControl1.Globe.Terrains.Add(strDataPath);
                objRes = terrain;
                if (terrain != null)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = terrain;
                    node.Text = terrain.Caption;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.Checked = terrain.Visible;
                    // 注意用insert不要用add，因为后加入的图层在上层                    
                    terrainManagerNode.Nodes.Insert(0, node);
                }
            }
            else
            {
                GSOLayer layer = globeControl1.Globe.Layers.Add(strDataPath);
                objRes = layer;               
            }
           
            RefreshDataTree();
            return objRes;
        }
        private void AddLayerData()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "支持格式(*.lrp,*.tif,*.tiff,*.img,*.asc,*.raw,*.dem,*.adf,*.idr,*.sid,*.ecw,*.e00,*.ers,*.hdr,*.grd,*.lrc,*.git,*.gtt,*.kml,*.lgd,*.shp,*.dxf,*.mif,*.tab,*.dgn,*.vec,*.gml,*.gft)|*.lrp;*.tif;*.tiff;*.img;*.asc;*.raw;*.dem;*.adf;*.idr;*.sid;*.ecw;*.e00;*.ers;*hdr;*.grd;*.lrc;*.git;*.gtt;*.kml;*.lgd;*.shp;*.dxf;*.mif;*.tab;*.dgn;*.vec;*.gml;*.gft|栅格数据(*.lrp)|*.lrp|栅格缓存(*.lrc)|*.lrc|KML数据(*.kml)|*.kml|矢量数据(*.lgd)|*.lgd|矢量缓存(*.gft)|*.gft|其它格式(*.*)|*.*||";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    AddLayerData(dlg.FileNames[i]);
                }
            }
        }
        void ReadKmlToMemoryLayer(String kmlPath)
        {
            GSODataset dataset = globeControl1.Globe.DataManager.AddFileDataset(kmlPath);
            GSOFeatureDataset fdataset = dataset as GSOFeatureDataset;
            if (fdataset != null)
            {
                GSOFeatures features = fdataset.GetAllFeatures();
                AddFeaturesNodeToMyPlace(features);
            }
        }

        void AddFeaturesNodeToMyPlace(GSOFeatures features)
        {
            if (features==null)
            {
                return;
            }

            for (Int32 i = 0; i < features.Length; i++)
            {
                GSOFeature feature = features[i];
                if (feature.Type == EnumFeatureType.FeatureFolder)
                {
                    GSOFeatureFolder featureFolder = (GSOFeatureFolder)feature;
                    AddFeaturesNodeToMyPlace(featureFolder.Features);
                }
                else
                {
                    TreeNode tempnode = new TreeNode();
                    tempnode.Text = feature.Name;
                    if (feature.Geometry != null)
                    {
                        switch (feature.Geometry.Type)
                        {
                            case EnumGeometryType.GeoPoint3D:
                            case EnumGeometryType.GeoMarker:
                                tempnode.ImageIndex = 3;
                                tempnode.SelectedImageIndex = 3;
                                break;
                            case EnumGeometryType.GeoPolyline3D:
                                tempnode.ImageIndex = 4;
                                tempnode.SelectedImageIndex = 4;
                                break;
                            case EnumGeometryType.GeoPolygon3D:
                                tempnode.ImageIndex = 5;
                                tempnode.SelectedImageIndex = 5;
                                break;
                            case EnumGeometryType.GeoModel:
                            case EnumGeometryType.GeoEntity:
                            case EnumGeometryType.GeoGroupEntity:
                            case EnumGeometryType.GeoSphereEntity:
                            case EnumGeometryType.GeoBoxEntity:
                            case EnumGeometryType.GeoEllipsoidEntity:
                            case EnumGeometryType.GeoCylinderEntity:
                            case EnumGeometryType.GeoFrustumEntity:
                            case EnumGeometryType.GeoEllipCylinderEntity:
                            case EnumGeometryType.GeoEllipFrustumEntity:
                            case EnumGeometryType.GeoRangeEllipsoidEntity:
                            case EnumGeometryType.GeoRangeEllipCylinderEntity:
                            case EnumGeometryType.GeoRangeEllipFrustumEntity:
                                tempnode.ImageIndex = 6;
                                tempnode.SelectedImageIndex = 6;
                                break;
                            case EnumGeometryType.GeoGroundOverlay:
                                tempnode.ImageIndex = 7;
                                tempnode.SelectedImageIndex = 7;
                                break;
                        }

                    }
                    GSOFeature newFeature = globeControl1.Globe.MemoryLayer.AddFeature(feature);
                    tempnode.Checked = newFeature.Visible;
                    tempnode.Tag = newFeature;
                    myPlaceNode.Nodes.Add(tempnode);
                }
            }
        }
        void sceneControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (featureTooltip.IsVisible())
            {
                featureTooltip.HideBalloon();
            }
        }
      
        void sceneControl1_FeatureMouseHover(object sender, FeatureMouseHoverEventArgs e)
        {
            if (e.Feature.Name != "")
            {
                featureTooltip.ShowBalloon((int)e.MousePos.X, (int)e.MousePos.Y, e.Feature.Name);
            }
        }

        void sceneControl1_FeatureMouseClick(object sender, FeatureMouseClickEventArgs e)
        {
            if (e.Feature.Description != "")
            {
                featureTooltip.HideBalloon();
                infoBalloon.HideBalloon();
                balloonEx.HideBalloon();

                GSOBalloonParam balloonParam = balloonEx.ParseParam(e.Feature.Description);

                if (balloonParam.ShowMode == EnumShowModeEx.BALLOON)
                {
                    infoBalloon.ShowBalloon((int)e.MousePos.X, (int)e.MousePos.Y, balloonParam.Content);
                }
                else
                {
                    balloonEx.ShowBalloonEx((int)e.MousePos.X, (int)e.MousePos.Y, balloonParam);
                }
            }
        }

        void sceneControl1_CameraBeginMove(object sender, CameraBeginMoveEventArgs e)
        {
            if (featureTooltip.IsVisible())
            {
                featureTooltip.HideBalloon();

            }
            if (infoBalloon.IsVisible())
            {
                infoBalloon.HideBalloon();
            }

            if (balloonEx.IsVisible())
            {
                balloonEx.HideBalloon();
            }
        }       
        
        void sceneControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (globeControl1.Globe.Action == EnumAction3D.SelectObject)
                {
                    GSOLayer layer = globeControl1.Globe.SelectedObjectLayer;
                    GSOFeature feature = globeControl1.Globe.SelectedObject;
                    LookSelobjAttribute(layer,feature);
                }
            }
        }
        void sceneControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                GSOPoint3d point;
                GSOLayer templayer;
                GSOFeature feature1 = globeControl1.Globe.HitTest(e.X, e.Y, out templayer, out point, false, true, 0);
                if (point.X == 0 && point.Y == 0 && point.Z == 0)
                {
                    point = globeControl1.Globe.ScreenToScene(e.X, e.Y);
                }
                GSOPoint3d pt = new GSOPoint3d();
                pt.X = point.X;
                pt.Y = point.Y;
                pt.Z = point.Z;

                if (addfitflag)
                {
                    WorldGIS.Forms.FrmAddPipeFitting frm = new WorldGIS.Forms.FrmAddPipeFitting(globeControl1, pt, globeControl1.Globe.DestLayerFeatureAdd);
                    frm.Show(this);
                    addfitflag = false;
                } 
            }
        }
        void sceneControl1_MouseDown(object sender, MouseEventArgs e)
        {
            rMouseUpContextMenuStrip.Hide();
            if (e.Button == MouseButtons.Right)
            {
                m_pntRMouseDown.X = e.X;
                m_pntRMouseDown.Y = e.Y;
            }
        }
        GSOFeature featureMouseRightClickAttr = null;
        void sceneControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.X - m_pntRMouseDown.X == 0 && e.Y - m_pntRMouseDown.Y == 0)
                {
                    featureMouseRightClickAttr = globeControl1.Globe.HitTest(e.X, e.Y, false, false);
                   
                    if (featureMouseRightClickAttr != null && featureMouseRightClickAttr.Geometry != null)
                    {
                        rMouseUpContextMenuStrip.Items["属性ToolStripMenuItem1"].Visible = true;

                        if (featureMouseRightClickAttr.Geometry.Type == EnumGeometryType.GeoPolygon3D)
                        {
                            rMouseUpContextMenuStrip.Items["框选导出图层ToolStripMenuItem"].Visible = true;
                        }
                    }
                    else
                    {
                        rMouseUpContextMenuStrip.Items["属性ToolStripMenuItem1"].Visible = false;
                        rMouseUpContextMenuStrip.Items["框选导出图层ToolStripMenuItem"].Visible = false;
                    }
                    rMouseUpContextMenuStrip.Show(globeControl1, e.X, e.Y);
                }
            }
        }          

        void sceneControl1_DrawAddFeature(object sender, DrawAddFeatureEventArgs e)
        {
            if(e.Layer!=null)
            {
                TreeNode node = FindTreeNodeByLayer(e.Layer);
                if(node!=null)
                {
                    RefreshTreeNodeLayerFeatureList(node);
                }            
            }
        }

        void sceneControl1_AfterKeyDownDeleteFeatureEvent(object sender, AfterKeyDownDeleteFeatureEventArgs e)
        {
            if(e.Layer!=null)
            {
                TreeNode node = FindTreeNodeByLayer(e.Layer);
                if (node != null)
                {
                    RefreshTreeNodeLayerFeatureList(node);
                }    
            }
        }

        void sceneControl1_TrackPolylineAnalysisEndEvent(object sender, TrackPolylineEndEventArgs e)
        {
            if (e.Polyline != null)
            {
                // 如果是剖面分析
                 if (ProfileAnalysisMenuItem.Checked)
                 {
                     GSOPoint3d pntMax,pntMin,pntStart,pntEnd;
                     GSOPoint3ds pnt3ds;
                     double dLineLength;
                     globeControl1.Globe.Analysis3D.ProfileAnalyse(e.Polyline, 100, out pnt3ds, out dLineLength, out pntMax, out pntMin, out pntStart, out pntEnd);
                     FrmAnalysisProfile dlg=new FrmAnalysisProfile();
                     dlg.m_pnt3ds = pnt3ds;
                     dlg.m_pntMax = pntMax;
                     dlg.m_pntMin = pntMin;
                     dlg.m_pntStart = pntStart;
                     dlg.m_pntEnd = pntEnd;
                     dlg.m_dXTotalLength = dLineLength;
                     dlg.m_dSphereLength = e.Polyline.GetSphereLength(6378137.0);
                     dlg.m_dSpaceLength = e.Polyline.GetSpaceLength(false,6378137.0);
                     dlg.m_dGroundLength = globeControl1.Globe.Analysis3D.GetGroundLength(e.Polyline,false,0);
                     dlg.Show(this);
                 }
                 else if (BaselineProfileAnalysisMenuItem.Checked) //基线剖面分析
                 {
                     FrmBaseLineProfillAnalysis dlg = new FrmBaseLineProfillAnalysis();
                     dlg.m_globe = globeControl1.Globe;
                     dlg.m_geopolyline = e.Polyline;
                     dlg.Show(this);
                 }
                 else if (LineDigPitMenuItem.Checked) //沿线挖坑
                 {
                     GSOGeoPolygon3D resPolygon=e.Polyline.CreateBuffer(m_dDigPitWidthAlongLine,false,0,false, false);
                     GSOGeoPit geoPit = new GSOGeoPit();
                     geoPit.PitPolygon = resPolygon;
                     if(m_bDigPitByDepth)
                     {
                         geoPit.PitDepth = m_dDigPitValue;
                         geoPit.PitDepthUsing = true;
                     }
                     else
                     {
                         geoPit.PitBottomAlt = m_dDigPitValue;
                         geoPit.PitDepthUsing = false;
                     }
                     
                     globeControl1.Globe.AddPit("", geoPit);
                     // 清除当前TrackPolygonAnalysis的痕迹
                     globeControl1.Globe.ClearLastTrackPolyline();
                 }
                 else if (横断面分析toolStripMenuItem3.Checked)
                 {
                     ArrayList arraylistPoint = new ArrayList();
                     ArrayList arraylistLine = new ArrayList();
                     for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
                     {
                         GSOLayer layer = globeControl1.Globe.Layers[i];
                         if (layer == null)
                         {
                             return;
                         }
                         if (layer.Visible == false)
                         {
                             continue;
                         }
                         GSOFeatureLayer featurelayer = layer as GSOFeatureLayer;
                         if (featurelayer != null)
                         {
                             GSOFeatures feats = featurelayer.GetAllFeatures(); //featurelayer.FindFeaturesInPolygon(polygon,false);// featurelayer.GetAllFeatures();
                             for (int j = 0; j < feats.Length; j++)
                             {
                                 GSOFeature feateline = feats[j];
                                 GSOGeoPolyline3D geoline = feateline.Geometry as GSOGeoPolyline3D;
                                 
                                 if (geoline != null)
                                 {
                                     GSOPoint3d pntIntersect1;
                                     GSOPoint3d pntIntersect2;
                                     double dHonLen;
                                     double dVerLen;
                                     double dNoIntersectStartRatio = 0;  
                                     bool isIntersect = globeControl1.Globe.Analysis3D.IsTwoGeoPolylineIntersect2D(e.Polyline, geoline);
                                     if (isIntersect)
                                     {
                                         double dDist = globeControl1.Globe.Analysis3D.ComputeTwoGeoPolylineDistance(e.Polyline, geoline, out pntIntersect1, out pntIntersect2, out dHonLen, out dVerLen, false, false, dNoIntersectStartRatio);
                                         if (dDist > -1)
                                         {
                                             arraylistPoint.Add(pntIntersect2);
                                             arraylistLine.Add(feateline);
                                         }
                                     }
                                     globeControl1.Globe.Action = EnumAction3D.ActionNull;                                    
                                 }
                             }
                         }
                     }
                     FrmAnalysisHengDuanMian frm = FrmAnalysisHengDuanMian.GetForm(arraylistPoint, arraylistLine, e.Polyline, globeControl1);                   
                     if (!frm.isShowFirst)
                     {
                         frm.Show(this);
                     }
                     frm.LoadChartEvent();
                     globeControl1.Globe.ClearAnalysis();
                 }
            }            
            globeControl1.Globe.Action = EnumAction3D.ActionNull;
            ActionToolMenuChecked();
        }

        void sceneControl1_TrackPolygonAnalysisEndEvent(object sender, TrackPolygonEndEventArgs e)
        {
            if (e.Polygon != null)
            {
                // 如果是剖面分析
                if (DigFillAnalysisMenuItem.Checked)
                {
                    FrmAnalysisDigFill dlg = new FrmAnalysisDigFill();
                    dlg.m_globe = globeControl1.Globe;
                    dlg.m_polygon3D = e.Polygon;
                    dlg.Show(this);
                }
                else if (NoSourceFloodSubmergeMenuItem.Checked)
                {
                    FrmFloodSubmergeAnalysis dlg = new FrmFloodSubmergeAnalysis();
                    dlg.m_globe = globeControl1.Globe;
                    dlg.m_polygon3D = e.Polygon;
                    dlg.Show(this);                    
                }
                else if (PolygonDigPitMenuItem.Checked)
                {
                    GSOGeoPit geoPit=new GSOGeoPit();
                    if (m_bDigPitByDepth)
                    {
                        geoPit.PitDepth = m_dDigPitValue;
                        geoPit.PitDepthUsing = true;
                    }
                    else
                    {
                        geoPit.PitBottomAlt = m_dDigPitValue;
                        geoPit.PitDepthUsing = false;
                    }
                    geoPit.PitPolygon = e.Polygon;
                    globeControl1.Globe.AddPit("", geoPit);

                    // 清除当前TrackPolygonAnalysis的痕迹
                    globeControl1.Globe.ClearLastTrackPolygon();
                    globeControl1.Globe.ClearLastTrackPolyline();
                }
                else if (trackPolygonEndFunction == "polygonOpenAttributes")
                {
                    TreeNode node = layerNodeContexMenu.Tag as TreeNode;
                    GSOLayer layer = node.Tag as GSOLayer;
                    if (layer != null)
                    {
                        GSOFeatures features = layer.FindFeaturesInPolygon(e.Polygon,false);
                        if (features == null || features.Length <= 0)
                        {
                            MessageBox.Show("选中的对象为空，请重新选择！","提示");
                            return;
                        }
                        FrmEditLayerAttributesByTable frm_editor = FrmEditLayerAttributesByTable.GetForm(layer, features, globeControl1);
                        frm_editor.SetDataTable();
                        if (!frm_editor.isShow)
                        {
                            return;
                        }
                        if (!frm_editor.isShowFirst)
                        {
                            frm_editor.Show(this);
                        }
                    }
                    globeControl1.Globe.ClearLastTrackPolygon();
                    globeControl1.Globe.Refresh();
                    trackPolygonEndFunction = "";
                }
                else if (trackPolygonEndFunction == "polygonDelete")
                {
                    GSOLayer layer = globeControl1.Globe.DestLayerFeatureAdd;
                    if (layer != null)
                    {
                        GSOFeatures fs = layer.FindFeaturesInPolygon(e.Polygon, false);
                        if (fs != null && fs.Length > 0)
                        {
                            for (int i = 0; i < fs.Length; i++)
                            {
                                fs[i].Delete();
                            }
                        }
                    }
                    globeControl1.Globe.ClearLastTrackPolygon();
                    globeControl1.Globe.Refresh();
                    return;
                }
            }
            
            globeControl1.Globe.Action = EnumAction3D.ActionNull;
            ActionToolMenuChecked();                    
        }
        
        private TreeNode FindTreeNodeByLayer(GSOLayer layer)
        {
            if (globeControl1.Globe.MemoryLayer.IsSameInnerObject(layer))
            {
                return myPlaceNode;
            }
            for (Int32 i = 0; i < layerManagerNode.Nodes.Count;i++ )
            {
                GSOLayer tempLayer = layerManagerNode.Nodes[i].Tag as GSOLayer;
                if (tempLayer.IsSameInnerObject(layer))
                {
                    return layerManagerNode.Nodes[i];
                }
            }
            return null;
        }
        private void SaveFiles(string filename, string filecontent)
        {
            FileStream fs = null;
            try
            {
                fs = File.Create(filename);            
                byte[] content = new UTF8Encoding(true).GetBytes(filecontent);           
                fs.Write(content, 0, content.Length);
                fs.Flush();
            }
            catch (Exception ex)
            {
                Log.PublishTxt(ex);
                MessageBox.Show(ex.Message,"提示");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void AddKmlLayer(GSOLayer layer)
        {
            if (layer != null)
            {
                TreeNode node = new TreeNode();
                node.Tag = layer;
                node.Text = layer.Caption;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Checked = layer.Visible;
                layerManagerNode.Nodes.Insert(0, node);
                VisitFeature3Ds(layer.GetAllFeatures(), node);
            }
        }
        private void VisitFeature3Ds(GSOFeatures feature3ds, TreeNode node)
        {
            for (int i = 0; i < feature3ds.Length; i++)
            {
                GSOFeature feature = feature3ds[i];
                if (feature.Type == EnumFeatureType.FeatureFolder)
                {
                    TreeNode tempnode = new TreeNode();
                    tempnode.Text = feature.Name;
                    tempnode.ImageIndex = 1;
                    tempnode.SelectedImageIndex = 1;
                    tempnode.Checked = feature.Visible;
                    tempnode.Tag = feature;
                    node.Nodes.Add(tempnode);
                    GSOFeatureFolder featureFolder = (GSOFeatureFolder)feature;
                    VisitFeature3Ds(featureFolder.Features, tempnode);
                }
                else
                {
                    TreeNode tempnode = new TreeNode();
                    tempnode.Text = feature.Name;
                    if (feature.Geometry != null)
                    {
                        switch (feature.Geometry.Type)
                        {
                            case EnumGeometryType.GeoPoint3D:
                            case EnumGeometryType.GeoMarker:
                                tempnode.ImageIndex = 3;
                                tempnode.SelectedImageIndex = 3;
                                break;
                            case EnumGeometryType.GeoPolyline3D:
                                tempnode.ImageIndex = 4;
                                tempnode.SelectedImageIndex = 4;
                                break;
                            case EnumGeometryType.GeoPolygon3D:
                                tempnode.ImageIndex = 5;
                                tempnode.SelectedImageIndex = 5;
                                break;
                            case EnumGeometryType.GeoModel:
                            case EnumGeometryType.GeoEntity:
                            case EnumGeometryType.GeoGroupEntity:
                            case EnumGeometryType.GeoSphereEntity:
                            case EnumGeometryType.GeoBoxEntity:
                            case EnumGeometryType.GeoEllipsoidEntity:
                            case EnumGeometryType.GeoCylinderEntity:
                            case EnumGeometryType.GeoFrustumEntity:
                            case EnumGeometryType.GeoEllipCylinderEntity:
                            case EnumGeometryType.GeoEllipFrustumEntity:
                            case EnumGeometryType.GeoRangeEllipsoidEntity:
                            case EnumGeometryType.GeoRangeEllipCylinderEntity:
                            case EnumGeometryType.GeoRangeEllipFrustumEntity:
                                tempnode.ImageIndex = 6;
                                tempnode.SelectedImageIndex = 6;
                                break;
                            case EnumGeometryType.GeoGroundOverlay:
                                tempnode.ImageIndex = 7;
                                tempnode.SelectedImageIndex = 7;
                                break;
                        }
                    }
                    tempnode.Checked = feature.Visible;
                    tempnode.Tag = feature;
                    node.Nodes.Add(tempnode);
                }
            }
        }

        private void layerTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if(e.Node.Tag.GetType() == typeof(GSOFeature))
                {
                    GSOFeature feature = e.Node.Tag as GSOFeature;
                    if (feature.Geometry == null || feature.Geometry.CameraState == null)
                    {
                        globeControl1.Globe.FlyToFeature(feature);
                    }
                    else
                    {
                        globeControl1.Globe.FlyToCameraState(feature.Geometry.CameraState);
                    }
                }
                else  
                {
                    GSORect2d rcBounds=new GSORect2d();
                    GSOLayer tempLayer = e.Node.Tag as GSOLayer;

                    if (tempLayer!=null)
                    {
                        rcBounds = tempLayer.LatLonBounds;
                    }
                    else if (e.Node.Tag.GetType() == typeof(GSOTerrain))
                    {
                        GSOTerrain tempTerrain = e.Node.Tag as GSOTerrain;
                        rcBounds = tempTerrain.LatLonBounds;
                    }

                    if(!rcBounds.IsEmpty())
                    {
                        GSOPoint2d pntCenter = rcBounds.Center;
                        GSOPoint3d pntPostion=new GSOPoint3d();
                        pntPostion.X = pntCenter.X;
                        pntPostion.Y = pntCenter.Y;
                        Double dMaxGeoLen = Math.Max(rcBounds.Width, rcBounds.Height);
                        Double dSize = dMaxGeoLen *Math.PI*6378137/360;
                       
                        pntPostion.Z = dSize;
                        globeControl1.Globe.FlyToPosition(pntPostion,EnumAltitudeMode.Absolute);
                    }
                }  
            }
        }

        private void CheckTreeNode(TreeNode node, Boolean bChecked)
        {
            CheckChildTreeNode(node, bChecked);
            globeControl1.Globe.Refresh();
        }
        private void CheckFatherTreeNode(TreeNode node, Boolean bChecked)
        {
            TreeNode fatherNode = node.Parent;
            if (bChecked)
            {
                while (fatherNode != null)
                {
                    fatherNode.Checked = true;
                    fatherNode = fatherNode.Parent;
                }
            }
            else
            {
                while (fatherNode != null)
                {
                    Boolean bHasVisible = false;
                    for (int i = 0; i < fatherNode.Nodes.Count; i++)
                    {
                        if (fatherNode.Nodes[i].Checked)
                        {
                            bHasVisible = true;
                            break;
                        }
                    }
                    fatherNode.Checked = bHasVisible;
                    fatherNode = fatherNode.Parent;
                }
            }
        }
        private void CheckChildTreeNode(TreeNode node, Boolean bChecked)
        {
            if (node == null)
            {
                return;
            }
            if (node.Tag != null)
            {
                if (node.Tag.GetType() == typeof(GSOFeatureFolder) ||
                    node.Tag.GetType() == typeof(GSOFeature))
                {
                    ((GSOFeature)node.Tag).SetVisibleDirectly(bChecked);
                }
                else
                {
                    GSOLayer curLayer = node.Tag as GSOLayer;
                    GSOTerrain curTerrain = node.Tag as GSOTerrain;
                    if (curLayer != null)
                    {
                        curLayer.Visible = bChecked;
                    }
                    else if (curTerrain != null)
                    {
                        curTerrain.Visible = bChecked;
                         
                    }
                }
            }
            // 递归处理子节点
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Checked = bChecked;
                CheckChildTreeNode(node.Nodes[i], bChecked);

            }
        }
        private void layerTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //防止该事件被多次引发
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckTreeNode(e.Node, e.Node.Checked);
            }
        }

        private void toolOpenFile_Click(object sender, EventArgs e)
        {
            AddLayerData();
        }

        private void MeasureDistance_Click(object sender, EventArgs e)
        {
            MeasureDistMenu_Click(sender, e);
        }

        private void MeasureHeight_Click(object sender, EventArgs e)
        {
            MesureHeightMenu_Click(sender, e);
        }

        private void AddPalceMark_Click(object sender, EventArgs e)
        {
            AddPlaceMarkMenu_Click(sender, e);
        }

        private void layerTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            layerTree.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node == myPlaceNode)
                {
                    atrributeToolStripMenuItem.Visible = false;

                    MyplaceEditableMenuItem.Checked = globeControl1.Globe.MemoryLayer.Editable;
                    MyPlaceSelectableMenuItem.Checked = globeControl1.Globe.MemoryLayer.Selectable;
                    MyPlaceFeatureAddLayerMenuItem.Checked = globeControl1.Globe.MemoryLayer.IsDestLayerFeatureAdd();
                    myPlaceContextMenu.Show(layerTree, e.X, e.Y);
                }
                // 如果是图层节点
                else if (e.Node.Parent == layerManagerNode || e.Node.Parent == terrainManagerNode)
                {
                    if (e.Node.Parent == layerManagerNode)
                    {
                        if (e.Node.Tag is GSOFeatureLayer)
                        {
                            //layerNodeContexMenu.Items["改变图层风格ToolStripMenuItem"].Visible = false;
                            GSOFeatureLayer featurelayer = e.Node.Tag as GSOFeatureLayer;
                            GSOFeatureDataset dataset = featurelayer.Dataset as GSOFeatureDataset;
                            //if (dataset.FieldCount <= 0)
                            //{
                            //    layerNodeContexMenu.Items["字段编辑ToolStripMenuItem"].Visible = false;
                            //}
                            //else
                            {
                                layerNodeContexMenu.Items["字段编辑ToolStripMenuItem"].Visible = true;
                            }
                        }
                        GSOLayer layer = e.Node.Tag as GSOLayer;
                        LayerEditableMenuItem.Checked = layer.Editable;
                        LayerSelectableMenuItem.Checked = layer.Selectable;
                        FeatureAddLayerMenuItem.Checked = layer.IsDestLayerFeatureAdd();
                        LayerEditableMenuItem.Visible = true;
                        LayerSelectableMenuItem.Visible = true;
                        FeatureAddLayerMenuItem.Visible = true;
                    }
                    else
                    {
                        layerNodeContexMenu.Items["改变图层风格ToolStripMenuItem"].Visible = false;
                        layerNodeContexMenu.Items["字段编辑ToolStripMenuItem"].Visible = false;
                        layerNodeContexMenu.Items["打开属性表ToolStripMenuItem"].Visible = false;

                        LayerEditableMenuItem.Visible = false;
                        LayerSelectableMenuItem.Visible = false;
                        FeatureAddLayerMenuItem.Visible = false;

                        /*
                        // 如果是地形那么可选择和可编辑就不显示了
                        treeContexMenue.Items[3].Visible = false;
                        treeContexMenue.Items[4].Visible = false;
                         * */
                    }

                    layerNodeContexMenu.Show(layerTree, e.X, e.Y);
                    layerNodeContexMenu.Tag = e.Node;

                }
                else if (e.Node.Tag != null)
                {
                    GSOFeature feature = e.Node.Tag as GSOFeature;
                    if (feature != null)
                    {
                        if (feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                        {
                            FlyAlongWithLineMenuItem.Visible = true;
                        }
                        else
                        {
                            FlyAlongWithLineMenuItem.Visible = false;
                        }

                        if (feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoPolygon3D)
                        {
                            ConvertToWaterMenuItem.Visible = true;
                        }
                        else
                        {
                            ConvertToWaterMenuItem.Visible = false;
                        }

                        if (feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoModel)
                        {
                            ShowSingleModelTreeMenuItem.Visible = true;
                        }
                        else
                        {
                            ShowSingleModelTreeMenuItem.Visible = false;
                        }

                        treeContexMenue.Show(layerTree, e.X, e.Y);
                        treeContexMenue.Tag = e.Node;
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddModelMenu_Click(sender, e);
        }

        private void FlyTo_Click(object sender, EventArgs e)
        {
            FlyToPlaceMenu_Click(sender, e);
        }

        private void LatLonGrid_Click(object sender, EventArgs e)
        {
            GridMenue_Click(sender, e);
        }
        private void SelModel_Click(object sender, EventArgs e)
        {
            SelObjMenu_Click(sender, e);
        }

        private void MoveModel_Click(object sender, EventArgs e)
        {
            MoveObjMenu_Click(sender, e);
        }

        private void scaleModel_Click(object sender, EventArgs e)
        {
            ScaleObjMenu_Click(sender, e);
        }

        private void RotateModel_Click(object sender, EventArgs e)
        {
            RotateObjMenu_Click(sender, e);
        }
        private void elvateModel_Click(object sender, EventArgs e)
        {
            ElevateMenu_Click(sender, e);
        }

        private void BrowsModel_Click(object sender, EventArgs e)
        {
            ActionBrowseMenu_Click(sender, e);
        }

        private void ExtraTerrain_Click(object sender, EventArgs e)
        {
            TerrainExtraMenu_Click(sender, e);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;
            GSOFeature feature3d = node.Tag as GSOFeature;
            if (node == null)
            {
                return;
            }
            if (feature3d != null)
            {
                feature3d.Delete();
                globeControl1.Globe.Refresh();
                node.Remove();
            }
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;
            if (node != null)
            {
                layerTree.LabelEdit = true;
                node.BeginEdit();
            }
        }

        private void layerTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;
            if (node == null)
            {
                return;
            }

            GSOFeature feature3d = node.Tag as GSOFeature;
            if (feature3d != null && e.Label != null)
            {
                feature3d.Name = e.Label;
                globeControl1.Refresh();
            }
            layerTree.LabelEdit = false;
        }
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseWorkSpace())
            {
                globeControl1.Globe.MemoryLayer.SaveAs(Path.GetDirectoryName(Application.ExecutablePath) + "/MyPlace.kml");
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void clearMeasure_Click(object sender, EventArgs e)
        {
            ClearMeasureMenu_Click(sender, e);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutUsMenu_Click(sender, e);           
        }

        private void atrributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;

            GSOLayer layer = node.Parent.Tag as GSOLayer;
            GSOFeature feature = node.Tag as GSOFeature;
           
            LookSelobjAttribute(layer,feature);
        }
        //大气层
        private void AtmospherMenue_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Atmosphere.Visible = !globeControl1.Globe.Atmosphere.Visible;          
            AtmospherMenue.Checked = globeControl1.Globe.Atmosphere.Visible;
            globeControl1.Refresh();
        }
        //经纬网
        private void GridMenue_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.LatLonGrid.Visible = !globeControl1.Globe.LatLonGrid.Visible;           
            GridMenue.Checked = globeControl1.Globe.LatLonGrid.Visible;
            globeControl1.Globe.Refresh();
        }

        private void 地下网格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.UnderGroundFloor.Visible = !globeControl1.Globe.UnderGroundFloor.Visible;
            地下网格ToolStripMenuItem.Checked = globeControl1.Globe.UnderGroundFloor.Visible;
            globeControl1.Globe.Refresh();
        }
      
        //状态条
        private void StatusMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.StatusBar.Visible = !globeControl1.Globe.StatusBar.Visible;
            StatusMenu.Checked = globeControl1.Globe.StatusBar.Visible;
            globeControl1.Globe.Refresh();
        }

        private void StatusBarTool_Click(object sender, EventArgs e)
        {
            StatusMenu_Click(sender, e);
        }
        //控制面板
        private void NavigationControlMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ControlPanel.Visible = !globeControl1.Globe.ControlPanel.Visible;
            NavigationControlMenu.Checked = globeControl1.Globe.ControlPanel.Visible;
            globeControl1.Refresh();
        }
        //工具条
        private void MainToolBarShowMenu_Click(object sender, EventArgs e)
        {
            navigate.Visible = !navigate.Visible;
            select.Visible = !select.Visible;
            line.Visible = !line.Visible;
            measure.Visible = !measure.Visible;
            move.Visible = !move.Visible;
            rotate.Visible = !rotate.Visible;
            elevate.Visible = !elevate.Visible;
            marker.Visible = !marker.Visible;
            model.Visible = !model.Visible;

            MainToolBarShowMenu.Checked = navigate.Visible;
            globeControl1.Globe.Refresh();
        }

        //平面距离量算
        private void MeasureDistMenu_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.Action == EnumAction3D.MeasureDistance)
            {
                if (!globeControl1.Globe.DistanceRuler.SpaceMeasure)
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                }
                else
                {
                    globeControl1.Globe.DistanceRuler.SpaceMeasure = false;
                }
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.MeasureDistance;
                globeControl1.Globe.DistanceRuler.SpaceMeasure = false;
            }

            ActionToolMenuChecked();
        }
        //平面面积量算
        private void MesureAreaMenu_Click(object sender, EventArgs e)
        {

            if (globeControl1.Globe.Action == EnumAction3D.MeasureArea)
            {
                if (!globeControl1.Globe.AreaRuler.SpaceMeasure)
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                }
                else
                {
                    globeControl1.Globe.AreaRuler.SpaceMeasure = false;

                }
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.MeasureArea;
                globeControl1.Globe.AreaRuler.SpaceMeasure = false;
            }

            ActionToolMenuChecked();
        }
        //距地面高度量算
        private void MesureHeightMenu_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.Action == EnumAction3D.MeasureHeight)
            {
                if (!globeControl1.Globe.HeightRuler.SpaceMeasure)
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                }
                else
                {
                    globeControl1.Globe.HeightRuler.SpaceMeasure = false;
                }                
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.MeasureHeight;
                globeControl1.Globe.HeightRuler.SpaceMeasure = false;
            }

            ActionToolMenuChecked();
        }
        //清除量算
        private void ClearMeasureMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ClearMeasure();
            globeControl1.Refresh();
        }

        //关于我们
        private void AboutUsMenu_Click(object sender, EventArgs e)
        {            
            globeControl1.Globe.UserBackgroundColorValid = true;
            globeControl1.Globe.UserBackgroundColor = Color.White;

            FrmAboutUs frm = new FrmAboutUs();
            frm.ShowDialog();            
        }

        private void FlyToPlaceMenu_Click(object sender, EventArgs e)
        {
            FrmFlyToLatLonPos frm = new FrmFlyToLatLonPos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.m_strLon.Trim() != "" && frm.m_strLat.Trim() != "")
                {
                    GSOPoint3d point3d = new GSOPoint3d();
                    point3d.X = Convert.ToSingle(frm.m_strLon);
                    point3d.Y = Convert.ToSingle(frm.m_strLat);
                    if (frm.m_strAlt.Trim() == "")
                    {
                        point3d.Z = 2000;
                    }
                    else
                    {
                        point3d.Z = Convert.ToSingle(frm.m_strAlt);
                    }
                    globeControl1.Globe.FlyToPosition(point3d, EnumAltitudeMode.RelativeToGround);
                }
            }
        }
       
        //选中对象
        private void SelObjMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.SelectObject;
            ActionToolMenuChecked();
        }
        //平移对象
        private void MoveObjMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.MoveObject;
            ActionToolMenuChecked();
        }
        //缩放对象
        private void ScaleObjMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.ScaleObject;
            ActionToolMenuChecked();
        }
        //浏览对象
        private void ActionBrowseMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.ActionNull;
            ActionToolMenuChecked();
        }
        //旋转对象
        private void RotateObjMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.RotateObject;
            ActionToolMenuChecked();
        }
        //升降对象
        private void ElevateMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.ElevateObject;
            ActionToolMenuChecked();
        }
        //绘制线
        private void AddLineMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.DrawPolyline;
            ActionToolMenuChecked();
        }

        private void LookAttrMenu_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelectedObject == null)
            {
                MessageBox.Show("对不起，您没有选中对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LookSelobjAttribute(globeControl1.Globe.SelectedObjectLayer,globeControl1.Globe.SelectedObject);
        }

        private void TerrainExtraMenu_Click(object sender, EventArgs e)
        {

            FrmTerrainExtra dlg = new FrmTerrainExtra();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.m_strTerrainExtra.Trim() != "")
                {
                    float selselvel = 0;
                    bool bl = float.TryParse(dlg.m_strTerrainExtra.Trim(), out selselvel);
                    if (bl)
                    {
                        globeControl1.Globe.TerrainExra = selselvel;
                        globeControl1.Globe.Refresh();
                    }
                }
            }
        }

        private void LockSceneMenu_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.MouseRoamingEnable = !globeControl1.Globe.MouseRoamingEnable;
            LockSceneMenu.Checked = !globeControl1.Globe.MouseRoamingEnable;
        }       

        private GSOGeoPolyline3D getSelectObject()
        {
            GSOGeoPolyline3D line = null;
            GSOFeature f = globeControl1.Globe.SelectedObject;
            if(f != null && f.Geometry != null)
            {
                line = f.Geometry as GSOGeoPolyline3D;
            }
            return line;
        }
        //快速飞行
        private void QuickFlyMenu_Click(object sender, EventArgs e)
        {
            GSOGeoPolyline3D line =  getSelectObject();
            if (line == null)
            {
                MessageBox.Show("请先选中一条线！");
                return;
            }
            m_dFlyAlongLineSpeed = 500;
            m_dFlyAlongLineRotateSpeed = 200;
            globeControl1.Globe.FlyAlongLineSpeed = m_dFlyAlongLineSpeed;
            globeControl1.Globe.FlyAlongLineRotateSpeed = m_dFlyAlongLineRotateSpeed;
            m_nFlyMode = 1;
            ActionToolMenuChecked();
            globeControl1.Globe.FlyEyeAlongWithLine(line, 2, 85, true, 0, false);
        }
        //中速飞行
        private void MidSpeedFlyMenu_Click(object sender, EventArgs e)
        {
            GSOGeoPolyline3D line = getSelectObject();
            if (line == null)
            {
                MessageBox.Show("请先选中一条线！");
                return;
            }
            m_dFlyAlongLineSpeed = 50;
            m_dFlyAlongLineRotateSpeed = 50;
            globeControl1.Globe.FlyAlongLineSpeed = m_dFlyAlongLineSpeed;
            globeControl1.Globe.FlyAlongLineRotateSpeed = m_dFlyAlongLineRotateSpeed;
            m_nFlyMode = 2;
            ActionToolMenuChecked();
            globeControl1.Globe.FlyEyeAlongWithLine(line, 2, 85, true, 0, false);
        }
        //慢速飞行
        private void SlowFlyMenu_Click(object sender, EventArgs e)
        {
            GSOGeoPolyline3D line = getSelectObject();
            if (line == null)
            {
                MessageBox.Show("请先选中一条线！");
                return;
            }
            m_dFlyAlongLineSpeed = 10;
            m_dFlyAlongLineRotateSpeed = 10;
            globeControl1.Globe.FlyAlongLineSpeed = m_dFlyAlongLineSpeed;
            globeControl1.Globe.FlyAlongLineRotateSpeed = m_dFlyAlongLineRotateSpeed;
            m_nFlyMode = 3;
            ActionToolMenuChecked();
            globeControl1.Globe.FlyEyeAlongWithLine(line, 2, 85, true, 0, false);
        }

        private void AddLine_Click(object sender, EventArgs e)
        {
            TreeNode featureAddLayerTreeNode = GetDestLayerFeatureAddTreeNode();
            if (featureAddLayerTreeNode == null)
            {
                MessageBox.Show("没有设置目标图层，请先设置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GSOLayer layer = featureAddLayerTreeNode.Tag as GSOLayer;
            if (!layer.Visible || !layer.Selectable || !layer.Editable)
            {
                MessageBox.Show("请确保目标图层可视、可选、可编辑!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            AddLineMenu_Click(sender, e);
        }

        private void DefineFlyLineMenu_Click(object sender, EventArgs e)
        {
            GSOGeoPolyline3D line = getSelectObject();
            if (line == null)
            {
                MessageBox.Show("请先选中一条线！");
                return;
            }
            FrmSetFlyParams dlg = new FrmSetFlyParams();

            dlg.dFlyAboveLine = m_dFlyAboveLine;
            dlg.dFlyAloneLineSpeed = m_dFlyAlongLineSpeed;
            dlg.dFlyAloneLineRotateSpeed = m_dFlyAlongLineRotateSpeed;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_dFlyAboveLine = dlg.dFlyAboveLine;
                m_dFlyAlongLineSpeed = dlg.dFlyAloneLineSpeed;
                m_dFlyAlongLineRotateSpeed = dlg.dFlyAloneLineRotateSpeed;
                globeControl1.Globe.FlyAlongLineSpeed = m_dFlyAlongLineSpeed;
                globeControl1.Globe.FlyAlongLineRotateSpeed = m_dFlyAlongLineRotateSpeed;
                globeControl1.Globe.FlyEyeAlongWithLine(line, m_dFlyAboveLine, 85, true, 0, false);
            }
        }

        private void goFindButton_Click_1(object sender, EventArgs e)
        {
            treeFind.Nodes.Clear();
            if (placeNameEBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入名称后再查询", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TreeNode node = new TreeNode();
            node.Text = "查询结果";
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.Checked = true;
            treeFind.Nodes.Add(node);

            for (int i = 0; i < globeControl1.Globe.Layers.Count; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer.Type == EnumLayerType.FeatureLayer)
                {
                    if (comboBoxCondition.Text == "包含")
                    {
                        GSOFeatures features = layer.GetFeatureByName(placeNameEBox.Text, false);
                        VisitFeature3Ds(features, treeFind.Nodes[0]);                        
                    }
                    else
                    {
                        GSOFeatures features = layer.GetFeatureByName(placeNameEBox.Text, true);
                        VisitFeature3Ds(features, treeFind.Nodes[0]);                       
                    }
                }
            }

            // 内存图层也查一下吧
            if (comboBoxCondition.Text == "包含")
            {
                GSOFeatures features = globeControl1.Globe.MemoryLayer.GetFeatureByName(placeNameEBox.Text, false);
                VisitFeature3Ds(features, treeFind.Nodes[0]);
            }
            else
            {
                GSOFeatures features = globeControl1.Globe.MemoryLayer.GetFeatureByName(placeNameEBox.Text, true);
                VisitFeature3Ds(features, treeFind.Nodes[0]);
            }

            treeFind.Nodes[0].Expand();
            if (treeFind.Nodes[0].Nodes.Count == 0)
            {
                treeFind.Nodes.Clear();
                MessageBox.Show("没有发现要查询对象", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void treeFind_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(GSOFeature))
            {
                GSOFeature feature = e.Node.Tag as GSOFeature;
                if (feature.CameraState != null)
                {
                    globeControl1.Globe.CameraState = feature.CameraState;
                }
                else
                {
                    globeControl1.Globe.FlyToFeature(feature);
                }
                globeControl1.Refresh();
            }
        }
        //移除所有
        private void RemoveAllFeature_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.MemoryLayer.RemoveAllFeature();
            myPlaceNode.Nodes.Clear();
            globeControl1.Globe.Refresh();
        }

        private void SaveMyPlaceAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.lgd|*.lgd|GoogleEarth KML数据(*.kml)|*.kml|*.shp|*.shp|*.dxf|*.dxf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                globeControl1.Globe.MemoryLayer.SaveAs(dlg.FileName);
            }
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            Int32 nIndex = node.Index;
            TreeNode parentNode = node.Parent;

            if (nIndex < parentNode.Nodes.Count - 1)
            {
                TreeNode newNode = (TreeNode)node.Clone();
                parentNode.Nodes.RemoveAt(nIndex);
                parentNode.Nodes.Insert(nIndex + 1, newNode);
            }
            if (parentNode == layerManagerNode)
            {
                globeControl1.Globe.Layers.MoveDown(nIndex);
            }
            else
            {
                globeControl1.Globe.Terrains.MoveDown(nIndex);
            }

            globeControl1.Globe.Refresh();
        }
        //移除图层
        private void RemoveLayer_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            if (node == null)
            {
                return;
            }
            TreeNode parentNode = node.Parent;
            Int32 nIndex = node.Index;

            if (parentNode == layerManagerNode)
            {
                string layername = globeControl1.Globe.Layers[nIndex].Name;
                globeControl1.Globe.Layers.Remove(nIndex);

                globeControl1.Globe.DataManager.DeleteDataSourceByName(layername); // 1， 多次添加同一个图层， lrp不行， kml可以。 2， datamanager removeby 3.remove delete difference
            }
            else
            {
                globeControl1.Globe.Terrains.Remove(nIndex);
            }
            node.Remove();
            globeControl1.Globe.Refresh();
        }

        private void 移除所有要素toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            if (node == null || node.GetNodeCount(false) < 1)
            {
                return;
            }
            TreeNode parentNode = node.Parent;
            Int32 nIndex = node.Index;

            if (parentNode == layerManagerNode)
            {
                GSOLayer layer = globeControl1.Globe.Layers[nIndex];
                if (layer != null)
                {
                    layer.RemoveAllFeature();
                    for (int i = node.Nodes.Count - 1;i>=0;i--)
                    {
                        node.Nodes[i].Remove();
                    }
                }                
            }
        }

        private void MoveUp_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            Int32 nIndex = node.Index;
            TreeNode parentNode = node.Parent;

            if (nIndex > 0)
            {
                TreeNode newNode = (TreeNode)node.Clone(); 

                parentNode.Nodes.RemoveAt(nIndex);
                parentNode.Nodes.Insert(nIndex - 1, newNode);
            }
            if (parentNode == layerManagerNode)
            {
                globeControl1.Globe.Layers.MoveUp(nIndex);
            }
            else
            {
                globeControl1.Globe.Terrains.MoveUp(nIndex);
            }

            globeControl1.Globe.Refresh();
        }

        //浏览模式
        private void CameraNavigation_Click(object sender, EventArgs e)
        {
            //globeControl1.Globe.CameraMode = EnumCameraMode.Navigation;
            CameraNavigationMenu.Checked = true;
            CameraWalkMenu.Checked = false;
            CameraUnderGroundMenu.Checked = false;
            switch (globeControl1.Globe.CameraMode)
            {
                case EnumCameraMode.UnderGround:
                    globeControl1.Globe.CameraMode = EnumCameraMode.Navigation;
                    GSOCameraState state = new GSOCameraState();
                    state.AltitudeMode = globeControl1.Globe.CameraState.AltitudeMode;
                    state.Altitude = globeControl1.Globe.CameraState.Altitude;
                    state.Distance = globeControl1.Globe.CameraState.Distance;
                    state.Heading = globeControl1.Globe.CameraState.Heading;
                    state.Latitude = globeControl1.Globe.CameraState.Latitude;
                    state.Longitude = globeControl1.Globe.CameraState.Longitude;
                    if (globeControl1.Globe.CameraState.Tilt < 95 && globeControl1.Globe.CameraState.Tilt > 85)
                    {
                        state.Tilt = 85;
                    }
                    else
                    {
                        state.Tilt = 180 - globeControl1.Globe.CameraState.Tilt;
                    }
                    globeControl1.Globe.JumpToCameraState(state);
                    break;
                case EnumCameraMode.Walk:
                    globeControl1.Globe.CameraMode = EnumCameraMode.Navigation;
                    break;
            }

            globeControl1.Globe.Refresh();
        }
        //行走模式
        private void CameraWalk_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.CameraMode = EnumCameraMode.Walk;
            CameraWalkMenu.Checked = true;
            CameraNavigationMenu.Checked = false;
            CameraUnderGroundMenu.Checked = false;
        }
        //地下模式
        private void CameraUnderGroundMenu_Click(object sender, EventArgs e)
        {
            //globeControl1.Globe.CameraMode = EnumCameraMode.UnderGround;
            CameraUnderGroundMenu.Checked = true;
            CameraNavigationMenu.Checked = false;
            CameraWalkMenu.Checked = false;
            switch (globeControl1.Globe.CameraMode)
            {
                case EnumCameraMode.Navigation:
                case EnumCameraMode.Walk:
                    globeControl1.Globe.CameraMode = EnumCameraMode.UnderGround;
                    GSOCameraState state = new GSOCameraState();
                    state.AltitudeMode = globeControl1.Globe.CameraState.AltitudeMode;
                    state.Altitude = globeControl1.Globe.CameraState.Altitude;
                    state.Distance = globeControl1.Globe.CameraState.Distance;
                    state.Heading = globeControl1.Globe.CameraState.Heading;
                    state.Latitude = globeControl1.Globe.CameraState.Latitude;
                    state.Longitude = globeControl1.Globe.CameraState.Longitude;
                    if (globeControl1.Globe.CameraState.Tilt < 95 && globeControl1.Globe.CameraState.Tilt > 85)
                    {
                        state.Tilt = 95;
                    }
                    else
                    {
                        state.Tilt = 180 - globeControl1.Globe.CameraState.Tilt;
                    }
                    globeControl1.Globe.JumpToCameraState(state);
                    break;
            }
            globeControl1.Globe.Refresh();
        }

        private void GroundTransSetMenu_Click(object sender, EventArgs e)
        {
            FrmSetGroundOpaque dlg = new FrmSetGroundOpaque();
            dlg.globe = globeControl1.Globe;
            dlg.Show(this);       
        }

        private void EnableMouseOverHighLightMenu_Click(object sender, EventArgs e)
        {
            EnableMouseOverHighLightMenu.Checked = !EnableMouseOverHighLightMenu.Checked;
        }

        private void EnableMouseOverHighLightMenu_CheckedChanged(object sender, EventArgs e)
        {
            globeControl1.Globe.FeatureMouseOverHighLight = EnableMouseOverHighLightMenu.Checked;
        }

        private void ClearWorkSpace()
        {           
            globeControl1.Globe.Layers.RemoveAll();
            globeControl1.Globe.Terrains.RemoveAll();
            globeControl1.Globe.DataManager.RemoveAllDataSources();

            terrainManagerNode.Nodes.Clear();
            layerManagerNode.Nodes.Clear();
            dataManagerNode.Nodes.Clear();
            globeControl1.Globe.Refresh();
        }
        private bool CloseWorkSpace()
        {
            if (globeControl1.Globe.Layers.Count > 0 || globeControl1.Globe.Terrains.Count>0)
            {
                DialogResult result = MessageBox.Show("是否保存数据?", "关闭工程", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes || result == DialogResult.No)
                {
                    if (result == DialogResult.Yes)
                    {
                        SaveAllData();
                    }
                    this.Text = m_strFormTitle;
                    m_strWorkSpacePath = "";
                    ClearWorkSpace();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;         
        }

        //打开工程
        private void OpenWorkSpaceMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "工程文件(*.gws)|*.gws|*.*|*.*||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CloseWorkSpace())
                {
                    globeControl1.Globe.OpenWorkSpace(dlg.FileName);
                    m_strWorkSpacePath = dlg.FileName;
                    this.Text = m_strFormTitle + " - " + dlg.FileName;
                    RefreshLayerAndTerrainTree();
                    globeControl1.Globe.Refresh();
                }                             
            }   
        }
        //关闭工程
        private void MenuItemCloseWorkSpace_Click(object sender, EventArgs e)
        {
            CloseWorkSpace();
        }
        //保存工程
        private void SaveWorkSpaceMenuItem_Click(object sender, EventArgs e)
        {
            if (m_strWorkSpacePath == "")
            {
                MenuItemSaveAsWorkSpace_Click(sender, e);
            }
            else
            {
                SaveAllData();
                globeControl1.Globe.SaveAsWorkSpace(m_strWorkSpacePath);
            }
        }
        //另存工程
        private void MenuItemSaveAsWorkSpace_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "工程文件(*.gws)|*.gws|*.*|*.*||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveAllData();
                globeControl1.Globe.SaveAsWorkSpace(dlg.FileName);
                m_strWorkSpacePath = dlg.FileName;
                this.Text = m_strFormTitle + " - " + dlg.FileName;
            }
        }
        //保存所有数据
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAllData();
        }

        private void 连接服务器toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmConnectServer connectServer = new FrmConnectServer();
            if (connectServer.ShowDialog() == DialogResult.OK)
            {
                if (!Utility.isNetworkConnectionSuccess(connectServer.m_strIP))
                {
                    MessageBox.Show("网络连接失败！", "提示");
                    return;
                }
                if (globeControl1.Globe.ConnectServer(connectServer.m_strIP, connectServer.m_nPort, connectServer.m_strUser, connectServer.m_strPsw))
                {

                }
            }
        }

        private void 连接数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDatabaseParaSettingSqlServer frm = new FrmDatabaseParaSettingSqlServer(globeControl1);
            frm.ShowDialog();           
        }
        //添加数据
        private void AddLayerDataMenu_Click(object sender, EventArgs e)
        {
            AddLayerData();
        }
        //判断球中是否已经添加过数据源
        private bool isGlobeContainsDataSource()
        {
            bool isGlobeContainsDataSource = false;
            for (int i = 0; i < globeControl1.Globe.DataManager.DataSourceCount; i++)
            {
                if (globeControl1.Globe.DataManager.GetDataSourceAt(i).Type == EnumDataSourceType.SqlServer
                    || globeControl1.Globe.DataManager.GetDataSourceAt(i).Type == EnumDataSourceType.Oracle)
                {
                    isGlobeContainsDataSource = true;
                    break;
                }
            }
            if (isGlobeContainsDataSource == false)
            {
                FrmMessageBox frmMessage = new FrmMessageBox();
                DialogResult result = frmMessage.ShowDialog();
                if (result == DialogResult.OK)
                {
                    连接数据库ToolStripMenuItem_Click("", null);
                }
                else if (result == DialogResult.No)
                {
                    连接Oracle数据库toolStripMenuItem6_Click("", null);
                }
                else
                {
                    return isGlobeContainsDataSource;
                }
            }
            for (int i = 0; i < globeControl1.Globe.DataManager.DataSourceCount; i++)
            {
                if (globeControl1.Globe.DataManager.GetDataSourceAt(i).Type == EnumDataSourceType.SqlServer
                    || globeControl1.Globe.DataManager.GetDataSourceAt(i).Type == EnumDataSourceType.Oracle)
                {
                    isGlobeContainsDataSource = true;
                    break;
                }
            }
            return isGlobeContainsDataSource;
        }
        
        //添加数据库图层
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            WorldGIS.Forms.FrmAddLayerFromDB frm = new WorldGIS.Forms.FrmAddLayerFromDB(globeControl1);
            frm.ShowDialog();
        }
        //添加地形
        private void AddTerrainMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "支持格式(*.lrp,*.dem)|*.lrp;*.dem|LocaSpace栅格数据(*.lrp)|*.lrp|其它格式(*.*)|*.*||";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    AddTerrainData(dlg.FileNames[i]);
                }
            }
        }
        //新建图层
        private void CreateNewDataMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "KML数据(*.kml)|*.kml|矢量数据(*.lgd)|*.lgd||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                object obj = AddLayerData(dlg.FileName);
                GSOLayer layer = obj as GSOLayer;
                if (layer != null)
                {
                    DialogResult result = MessageBox.Show("是否将新图层设置为目标图层?", "新建图层", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        layer.Editable = true;
                        globeControl1.Globe.DestLayerFeatureAdd = layer;

                        if (globeControl1.Globe.DestLayerFeatureAdd != null || globeControl1.Globe.DestLayerFeatureAdd.Caption == "")
                        {
                            myPlaceNode.NodeFont = new Font(layerTree.Font, FontStyle.Regular);
                        }
                        else
                        {
                            for (int i = 0; i < layerManagerNode.Nodes.Count; i++)
                            {
                                if (layerManagerNode.Nodes[i].Text == globeControl1.Globe.DestLayerFeatureAdd.Caption)
                                {
                                    layerManagerNode.Nodes[i].NodeFont = new Font(layerTree.Font, FontStyle.Regular);
                                }
                            }
                        }

                        if (layerManagerNode.Nodes[0].Text == layer.Caption)
                        {
                            layerManagerNode.Nodes[0].NodeFont = new Font(layerTree.Font, FontStyle.Bold);
                        }

                        statusStrip1.Items[1].Text = "当前目标图层：" + layer.Caption;
                    }
                }
            }
        }
        //框选导出图层
        private void 框选导出图层toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelObjectCount <= 0)
            {
                MessageBox.Show("请先选中一个面对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<GSOGeoPolygon3D> list = new List<GSOGeoPolygon3D>();
            GSOLayer newlayer = new GSOFeatureLayer();
            for (int i = 0; i < globeControl1.Globe.SelObjectCount; i++)
            {
                GSOFeature newfeature = new GSOFeature();
                globeControl1.Globe.GetSelectObject(0, out newfeature, out newlayer);
                if (newfeature.Geometry.Type == EnumGeometryType.GeoPolygon3D)
                {
                    GSOGeoPolygon3D polygon = (GSOGeoPolygon3D)newfeature.Geometry;
                    list.Add(polygon);
                }
            }
            if (list.Count > 0)
            {
                FrmParticalExportLayer exportLayer = new FrmParticalExportLayer(globeControl1, list);
                exportLayer.Show(this);
            }
            else
            {
                MessageBox.Show("请选中一个或者多个面对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void 日志管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmLogManager logManager = new FrmLogManager(globeControl1);
            logManager.Show(this);
        }
        //退出系统
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RefreshLayerAndTerrainTree()
        {
            int nLayerCount = globeControl1.Globe.Layers.Count;
            int nTerrainCount = globeControl1.Globe.Terrains.Count;

            terrainManagerNode.Nodes.Clear();
            layerManagerNode.Nodes.Clear();
            int i = 0;
            for (i = 0; i < nLayerCount; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer != null)
                {
                    if (layer.Type == EnumLayerType.ImageLayer)
                    {
                        TreeNode node = new TreeNode();
                        node.Tag = layer;
                        node.Text = layer.Caption;
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;
                        node.Checked = layer.Visible;
                        // 注意要用add
                        layerManagerNode.Nodes.Add(node);
                    }
                    else
                    {
                        TreeNode node = new TreeNode();
                        node.Tag = layer;
                        node.Text = layer.Caption;
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;
                        node.Checked = layer.Visible;
                        // 注意要用add
                        layerManagerNode.Nodes.Add(node);
                        VisitFeature3Ds(layer.GetAllFeatures(), node);
                    }
                }
            }
            for (i = 0; i < nTerrainCount; i++)
            {

                GSOTerrain terrain = globeControl1.Globe.Terrains[i];
                if (terrain != null)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = terrain;
                    node.Text = terrain.Caption;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.Checked = terrain.Visible;
                    // 注意要用add
                    terrainManagerNode.Nodes.Add(node);
                }
            }

            // 展开
            layerManagerNode.Expand();
            terrainManagerNode.Expand();
            RefreshDataTree();
        }
       
        private void AntiAntialiasingMenuItem_Click(object sender, EventArgs e)
        {
            AntiAntialiasingMenuItem.Checked = !AntiAntialiasingMenuItem.Checked;
        }

        private void AntiAntialiasingMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            globeControl1.Globe.Antialiasing = AntiAntialiasingMenuItem.Checked;
            globeControl1.Refresh();
        }

        private void ShaderAtmosphereMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Atmosphere.ShaderUsing = !globeControl1.Globe.Atmosphere.ShaderUsing;
            ShaderAtmosphereMenuItem.Checked = !ShaderAtmosphereMenuItem.Checked;
            globeControl1.Refresh();
        }

        private void ModelWireFrameMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ModelRenderDetail = EnumRenderDetail.WireFrame;
            ModelWireFrameMenuItem.Checked = true;
            ModelTextureMenuItem.Checked = false;
            ModelSolidMenuItem.Checked = false;
        }

        //模型点模式
        private void ModelPointMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ModelRenderDetail = EnumRenderDetail.Points;

            ModelWireFrameMenuItem.Checked = false;
            
            //ModelPointMenuItem.Checked = true;
            ModelTextureMenuItem.Checked = false;
            ModelSolidMenuItem.Checked = false;
        }

        private void ModelSolidMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ModelRenderDetail = EnumRenderDetail.Solid;
            ModelWireFrameMenuItem.Checked = false;
            //ModelPointMenuItem.Checked = false;
            ModelTextureMenuItem.Checked = false;
            ModelSolidMenuItem.Checked = true;
        }

        private void ModelTextureMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ModelRenderDetail = EnumRenderDetail.Texture;
            ModelWireFrameMenuItem.Checked = false;
            ModelTextureMenuItem.Checked = true;
            ModelSolidMenuItem.Checked = false;
        }

        private void SaveAllData()
        {
            globeControl1.Globe.MemoryLayer.SaveAs(Path.GetDirectoryName(Application.ExecutablePath) + "/MyPlace.kml");

            int nCount = globeControl1.Globe.Layers.Count;
            for (int i = 0; i < nCount; i++)
            {
                GSOLayer layer = globeControl1.Globe.Layers[i];
                if (layer != null)
                {
                    layer.Save();
                }
            }
        }
       

        private void FlyAlongWithLineMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;

            GSOFeature feature = node.Tag as GSOFeature;

            if (feature != null && feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
            {
                // globeControl1.Globe.FlyEyeAlongWithLine((GSOGeoPolyline3D)feature.Geometry, 0, 0, 85);
                globeControl1.Globe.FlyEyeAlongWithLine((GSOGeoPolyline3D)feature.Geometry, m_dFlyAboveLine, 85, true, 0, false);
                globeControl1.Globe.CurFlyID = 4;
            }
        }

        private void FlyAroundCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 永久旋转
            //globeControl1.Globe.FlyAroundCenter();
            // 旋转720度
            // globeControl1.Globe.FlyAroundCenter(720,EnumFlyRepeatValueType.Degrees);
            // 旋转10秒钟
            globeControl1.Globe.FlyAroundCenter(10000, EnumFlyRepeatValueType.MiliSeconds);
            globeControl1.Globe.CurFlyID = 1;
        }

        private void FlyAroundEyeMenuItem_Click(object sender, EventArgs e)
        {
            //globeControl1.Globe.FlyAroundEye();
            globeControl1.Globe.FlyAroundEye(720, EnumFlyRepeatValueType.Degrees);
            globeControl1.Globe.CurFlyID = 2;
        }

        private void RotateAroundObjectMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;
            GSOFeature feature = node.Tag as GSOFeature;
            if (feature != null)
            {
                // globeControl1.Globe.FlyEyeAlongWithLine((GSOGeoPolyline3D)feature.Geometry, 0, 0, 85);
                globeControl1.Globe.FlyAroundFeature(feature, true, 0, EnumFlyRepeatValueType.Degrees);
                globeControl1.Globe.CurFlyID = 3;
            }
        }

        private void DynamicCarMenuItem_Click(object sender, EventArgs e)
        {
            GSORoute route = new GSORoute();
            route.Add(116.601, 39.901, 0);
            route.Add(116.602, 39.901, 0);
            route.Add(116.603, 39.901, 0);
            route.Add(116.603, 39.902, 0);
            route.Add(116.603, 39.903, 0);
            route.Add(116.603, 39.904, 0);
            route.Speed = 50;
            route.RotateSpeed = 50;
            route.AltitudeMode = EnumAltitudeMode.ClampToGround;
           
            GSOGeoModel geoModel = new GSOGeoModel();
            geoModel.FilePath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/model/tank.3ds";
                             
            GSOGeoDynamicRoute geoDynamicRoute = new GSOGeoDynamicRoute();
            geoDynamicRoute.TimerInterval = 20;
            geoDynamicRoute.Route = route;
            geoDynamicRoute.ActorGeometry = geoModel;
            geoDynamicRoute.Play();

            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoDynamicRoute;

            GSOLabel gsoLabel = new GSOLabel();
            gsoLabel.Text = "中-59";

            feature.Label = gsoLabel;        

            globeControl1.Globe.MemoryLayer.AddFeature(feature);
            GSOCameraState cameraState = new GSOCameraState();
            cameraState.Longitude = 116.601;
            cameraState.Latitude = 39.901;
            cameraState.Altitude = 900;
            cameraState.Tilt = 0;
            cameraState.Heading = 0;
            globeControl1.Globe.FlyToCameraState(cameraState);            
        }

        private void CopterMenuItem_Click(object sender, EventArgs e)
        {          
            GSORoute route = new GSORoute();
            route.Add(116.601, 39.901, 1000);
            route.Add(116.603, 39.901, 1000);
            route.Add(116.605, 39.901, 1000);
            route.Add(116.605, 39.901, 1000);
            route.Add(116.605, 39.901, 1000);
            route.Add(116.605, 39.901, 1000);
            route.Add(116.605, 39.903, 1000);
            route.Add(116.605, 39.905, 1000);
            route.Add(116.605, 39.907, 1000);
            route.Speed = 200;
            route.RotateSpeed = 50;
            route.AltitudeMode = EnumAltitudeMode.Absolute;
            route.CircleRoute = true;
          
            GSOGeoModel geoModel = new GSOGeoModel();
            geoModel.FilePath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/model/客机.3ds";
            geoModel.RotateZ = -90;
            geoModel.SetScale(0.1, 0.1, 0.1);             
            GSOGeoDynamicRoute geoDynamicRoute = new GSOGeoDynamicRoute();
            geoDynamicRoute.TimerInterval = 20;
            geoDynamicRoute.Route = route;
            geoDynamicRoute.ActorGeometry = geoModel;
            geoDynamicRoute.Play();

            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoDynamicRoute;
            GSOLabel gsoLabel = new GSOLabel();
            gsoLabel.Text = "国航A9";
            feature.Label = gsoLabel;

            globeControl1.Globe.MemoryLayer.AddFeature(feature);

            GSOCameraState cameraState = new GSOCameraState();
            cameraState.Longitude = 116.601;
            cameraState.Latitude = 39.901;
            cameraState.Altitude = 2500;
            cameraState.Tilt = 0;
            cameraState.Heading = 0;
            globeControl1.Globe.FlyToCameraState(cameraState);                
        }

        private void MissileMenuItem_Click(object sender, EventArgs e)
        {        
            GSORoute route = new GSORoute();
         
            route.Add(116.601, 39.902, 100);
            route.Add(116.602, 39.902, 150);
            route.Add(116.603, 39.902, 200);
            route.Add(116.603, 39.902, 200);
            route.Add(116.603, 39.902, 200);
            route.Add(116.603, 39.902, 200);
            route.Add(116.604, 39.902, 250);
            route.Add(116.605, 39.902, 300);
            route.Add(116.606, 39.902, 250);
            route.Add(116.607, 39.902, 200);
            route.Add(116.608, 39.902, 150);
            route.Add(116.609, 39.902, 100);
            route.Speed = 500;
            route.RotateSpeed = 200;
            route.AltitudeMode = EnumAltitudeMode.Absolute;
            route.CircleRoute=false;
          
            GSOGeoModel geoModel = new GSOGeoModel();
            geoModel.FilePath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/model/aim9.3ds";
            geoModel.SetScale(30, 30, 30);

            GSOGeoDynamicRoute geoDynamicRoute = new GSOGeoDynamicRoute();
            geoDynamicRoute.TimerInterval = 20;
            geoDynamicRoute.Route = route;
            geoDynamicRoute.ActorGeometry = geoModel;
            geoDynamicRoute.Play();

            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoDynamicRoute;
            GSOLabel gsoLabel = new GSOLabel();
            gsoLabel.Text = "爱国者";
            feature.Label = gsoLabel;

            globeControl1.Globe.MemoryLayer.AddFeature(feature);

            GSOCameraState cameraState = new GSOCameraState();
            cameraState.Longitude = 116.605;
            cameraState.Latitude = 39.902;
            cameraState.Altitude = 100;
            cameraState.Tilt = 85;
            cameraState.Heading = 0;
            globeControl1.Globe.FlyToCameraState(cameraState);             
        }

        private void SaveLayerMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            TreeNode parentNode = node.Parent;
            Int32 nIndex = node.Index;

            if (parentNode == layerManagerNode)
            {
                GSODataset dateSet = globeControl1.Globe.Layers[nIndex].Dataset;
                if (dateSet != null)
                {
                    dateSet.Save();
                }
            }
            else
            {
                //globeControl1.Globe.Terrains[nIndex].Save();
            }
        }

        private void SaveAsLayerMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            TreeNode parentNode = node.Parent;
            Int32 nIndex = node.Index;

            if (parentNode == layerManagerNode)
            {
                GSOLayer layer = globeControl1.Globe.Layers[nIndex];
                if (layer.Type == EnumLayerType.FeatureLayer)
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "*.lgd|*.lgd|*.kml|*.kml|*.shp|*.shp|*.dxf|*.dxf|*.tab|*.tab|*.dgn|*.dgn|*.gml|*.gml|*.*|*.*||";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        layer.SaveAs(dlg.FileName);
                    }
                }
            }
        }

        private void WaterPipeMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = globeControl1.Globe.Layers["WaterPipeDemo"];
            if (layer != null)
            {
                GSOCameraState cameraState = new GSOCameraState();
                cameraState.Longitude = 120.122613878251;
                cameraState.Latitude = 37.3997895601905;
                cameraState.Altitude = 3.21685825381428;
                cameraState.Heading = 30.3528709511283;
                cameraState.Tilt = 84.361905816876;
                globeControl1.Globe.FlyToCameraState(cameraState);
                timerWaterPipe.Start();
            }
        }

        private void timerWaterPipe_Tick(object sender, EventArgs e)
        {
            m_nWaterPipeDemoTick++;
            GSOStyle style3d = null;
            GSOEntityStyle3D modeStyle3d = null;
            GSOLayer layer = globeControl1.Globe.Layers["WaterPipeDemo"];
            if (layer != null)
            {
                GSOFeatures features = layer.GetAllFeatures();
                GSOFeatures tempFeatures = ((GSOFeatureFolder)features[0]).Features;

                GSOFeature feature = tempFeatures[24];
                feature.Visible = false;

                for (int i = 25; i < tempFeatures.Length - 1; i++)
                {
                    feature = tempFeatures[i];
                    int nCurIndex = m_nWaterPipeDemoTick % 6;
                    if ((i - 25) == nCurIndex)
                    {
                        feature.Visible = true;
                        style3d = feature.Geometry.Style;
                        if (style3d == null)
                        {
                            style3d = new GSOEntityStyle3D();
                        }
                        modeStyle3d = (GSOEntityStyle3D)style3d;

                        modeStyle3d.UsingSingleColor = true;
                        modeStyle3d.EntityColor = Color.FromArgb(200, 0, 0, 255);
                        feature.Geometry.Style = modeStyle3d;
                    }
                    else if (((GSOGeoModel)feature.Geometry).IsLoaded())
                    {
                        feature.Visible = false;
                    }
                }
                feature = tempFeatures[tempFeatures.Length - 1];
                feature.Visible = true;
                style3d = feature.Geometry.Style;
                if (style3d == null)
                {
                    style3d = new GSOEntityStyle3D();
                }
                modeStyle3d = (GSOEntityStyle3D)style3d;

                modeStyle3d.UsingSingleColor = true;
                modeStyle3d.EntityColor = Color.FromArgb(100, 128, 128, 128);
                feature.Geometry.Style = modeStyle3d;

                globeControl1.Refresh();
            }
        }

        private void DrawPolygonMenuItem_Click(object sender, EventArgs e)
        {            
            globeControl1.Globe.Action = EnumAction3D.DrawPolygon;
            ActionToolMenuChecked();
        }

        private void RefreshMyplaceListMenuItem_Click(object sender, EventArgs e)
        {
            myPlaceNode.Nodes.Clear();
            VisitFeature3Ds(globeControl1.Globe.MemoryLayer.GetAllFeatures(), myPlaceNode);
        }
        private void MyplaceEditableMenuItem_Click(object sender, EventArgs e)
        {
            MyplaceEditableMenuItem.Checked = !MyplaceEditableMenuItem.Checked;
            globeControl1.Globe.MemoryLayer.Editable = MyplaceEditableMenuItem.Checked;
        }

        private void MyPlaceSelectableMenuItem_Click(object sender, EventArgs e)
        {
            MyPlaceSelectableMenuItem.Checked = !MyPlaceSelectableMenuItem.Checked;
            globeControl1.Globe.MemoryLayer.Selectable = MyPlaceSelectableMenuItem.Checked;
        }

        private void LayerEditableMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            TreeNode parentNode = node.Parent;            

            if (parentNode == layerManagerNode)
            {
                GSOLayer layer = node.Tag as GSOLayer;
                LayerEditableMenuItem.Checked = !LayerEditableMenuItem.Checked;
                layer.Editable = LayerEditableMenuItem.Checked;
            }
        }

        private void LayerSelectableMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            TreeNode parentNode = node.Parent;
            Int32 nIndex = node.Index;

            if (parentNode == layerManagerNode)
            {
                GSOLayer layer = globeControl1.Globe.Layers[nIndex];
                LayerSelectableMenuItem.Checked = !LayerSelectableMenuItem.Checked;
                layer.Selectable = LayerSelectableMenuItem.Checked;
            }
        }
        private void RefreshTreeNodeLayerFeatureList(TreeNode layerTreeNode)
        {
            layerTreeNode.Nodes.Clear();
            GSOLayer layer = (GSOLayer)layerTreeNode.Tag;
            // 只将类型为内存数据集的图层列出，如果是其它类型的数据集可能数据量太大，没发显示在树控件中
            if (layer.Dataset is GSOFeatureDataset)
            {
                VisitFeature3Ds(layer.GetAllFeatures(), layerTreeNode);
            }            
        }

        private void RefreshLayerFeatureListMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            TreeNode parentNode = node.Parent;
            Int32 nIndex = node.Index;

            if (parentNode == layerManagerNode)
            {
                RefreshTreeNodeLayerFeatureList(node);
            }
        }

        private void DrawPolygonToolButton_Click(object sender, EventArgs e)
        {
            TreeNode featureAddLayerTreeNode = GetDestLayerFeatureAddTreeNode();
            if (featureAddLayerTreeNode == null)
            {
                MessageBox.Show("没有设置目标图层，请先设置!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GSOLayer layer =featureAddLayerTreeNode.Tag as GSOLayer;
            if (!layer.Visible || !layer.Selectable || !layer.Editable)
            {
                MessageBox.Show("请确保目标图层可视、可选、可编辑!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DrawPolygonMenuItem_Click(sender, e);
        }

        private TreeNode GetDestLayerFeatureAddTreeNode()
        {
            if (myPlaceNode.Tag != null && ((GSOLayer)myPlaceNode.Tag).IsDestLayerFeatureAdd())
            {
                    return myPlaceNode;
            }
            for (int i = 0; i < layerManagerNode.Nodes.Count; i++)
            {
                TreeNode tempNode = layerManagerNode.Nodes[i];
                if (tempNode.Tag != null && ((GSOLayer)tempNode.Tag).IsDestLayerFeatureAdd())
                {
                    return tempNode;
                }
            }
            return null;
        }

        private void AddMultiModeMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddMultiModel dlg = new FrmAddMultiModel();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode featureAddLayerTreeNode = GetDestLayerFeatureAddTreeNode();
                if (featureAddLayerTreeNode != null)
                {
                    GSOLayer featureAddLayer = (GSOLayer)featureAddLayerTreeNode.Tag;
                    int nSelFileNum = dlg.m_arryFileSel.Count;
                    for (int i = 0; i < nSelFileNum; i++)
                    {
                        string strFilePath = dlg.m_arryFileSel[i].ToString();
                        string strFileExt = Path.GetExtension(strFilePath).ToLower();
                        string strFileName = Path.GetFileName(strFilePath);
                        int nIndex = strFileName.LastIndexOf('.');
                        string strTitle = strFileName.Substring(0, nIndex);

                        GSOFeature f = new GSOFeature();
                        GSOGeoModel model = new GSOGeoModel();
                        model.FilePath = strFilePath;

                        if (strFileExt == ".gcm") // 如果是gcm需要提前加载坐标信息
                        {
                            model.LoadGCMCoordInfo();
                            if (!model.IsCoordInfoValid())
                            {
                                GSOPoint3d pt = new GSOPoint3d();
                                pt.X = globeControl1.Globe.CameraState.Longitude;
                                pt.Y = globeControl1.Globe.CameraState.Latitude;
                                pt.Z = model.Position.Z;  // 注意z值还是要保留下来的
                                model.Position = pt;
                            }
                            model.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                        }
                        else
                        {
                            GSOPoint3d pt = new GSOPoint3d();
                            pt.X = globeControl1.Globe.CameraState.Longitude;
                            pt.Y = globeControl1.Globe.CameraState.Latitude;
                            pt.Z = 0;
                            model.Position = pt;
                            model.AltitudeMode = EnumAltitudeMode.ClampToGround;
                        }

                        f.Geometry = model;
                        f.Name = strTitle;

                        featureAddLayer.AddFeature(f);                      
                    }
                    RefreshTreeNodeLayerFeatureList(featureAddLayerTreeNode);
                    globeControl1.Globe.Refresh();                     
                }
            }
        }

        private void MyPlaceFeatureAddLayerMenuItem_Click(object sender, EventArgs e)
        {             
            if (!MyPlaceFeatureAddLayerMenuItem.Checked)
            {
                MyPlaceFeatureAddLayerMenuItem.Checked = true;
                globeControl1.Globe.DestLayerFeatureAdd = globeControl1.Globe.MemoryLayer;

                for (int i = 0; i < layerManagerNode.Nodes.Count; i++)
                {
                    layerManagerNode.Nodes[i].NodeFont = new Font(layerTree.Font, FontStyle.Regular);
                }
                myPlaceNode.NodeFont = new Font(layerTree.Font, FontStyle.Bold);

                statusStrip1.Items[1].Text = "当前目标图层：" + myPlaceNode.Text;
            }                     
        }

        private void FeatureAddLayerMenuItem_Click(object sender, EventArgs e)
        {
            if (!FeatureAddLayerMenuItem.Checked)
            {

                if (globeControl1.Globe.DestLayerFeatureAdd == null || globeControl1.Globe.DestLayerFeatureAdd.Caption == "")
                {
                    myPlaceNode.NodeFont = new Font(layerTree.Font, FontStyle.Regular);
                }
                else
                {
                    for (int i = 0; i < layerManagerNode.Nodes.Count; i++)
                    {
                        if (layerManagerNode.Nodes[i].Text == globeControl1.Globe.DestLayerFeatureAdd.Caption)
                        {
                            layerManagerNode.Nodes[i].NodeFont = new Font(layerTree.Font, FontStyle.Regular);
                        }
                    }
                }
                
               
                TreeNode node = layerNodeContexMenu.Tag as TreeNode;
                FeatureAddLayerMenuItem.Checked = true;
                globeControl1.Globe.DestLayerFeatureAdd = (GSOLayer)node.Tag;

                node.NodeFont = new Font(layerTree.Font, FontStyle.Bold);

                statusStrip1.Items[1].Text = "当前目标图层：" + node.Text;
            }         
        }

        private void ShowAddFeatureDlg(GSOFeature newFeature)
        {
            TreeNode featureAddLayerTreeNode = GetDestLayerFeatureAddTreeNode();
            if (featureAddLayerTreeNode == null)
            {
                MessageBox.Show("添加失败！没有设置目标图层，请先设置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 先添加到图层中，这样可以预览效果
            GSOLayer featureAddLayer = (GSOLayer)featureAddLayerTreeNode.Tag;
            featureAddLayer.AddFeature(newFeature);
            globeControl1.Refresh();

            FrmFeatureInfo dlg = new FrmFeatureInfo(newFeature, featureAddLayer, globeControl1);           
            DialogResult result = dlg.ShowDialog(this);
            if (result == DialogResult.OK)
            {               
                RefreshTreeNodeLayerFeatureList(featureAddLayerTreeNode);
            }
            else
            {
                newFeature.Delete();
            }
        }
        private void AddPlaceMarkMenu_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            GSOGeoMarker p = new GSOGeoMarker();
            GSOMarkerStyle3D style = new GSOMarkerStyle3D();
            style.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/DefaultIcon.png";
            p.Style = style;
            p.X = globeControl1.Globe.CameraState.Longitude;
            p.Y = globeControl1.Globe.CameraState.Latitude;
            newFeature.Geometry = p;
            newFeature.Name = "我的地标";
            ShowAddFeatureDlg(newFeature);
        }
        private void AddModelMenu_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            GSOGeoModel model = new GSOGeoModel();
            GSOPoint3d pt = new GSOPoint3d();
            pt.X = globeControl1.Globe.CameraState.Longitude;
            pt.Y = globeControl1.Globe.CameraState.Latitude;
            pt.Z = 0;
            model.Position = pt;
            newFeature.Geometry = model;
            newFeature.Name = "我的模型";
            ShowAddFeatureDlg(newFeature);
        }

        private void MenuItemAddDynamicMarker_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            GSOGeoDynamicMarker geoDynamicMarker = new GSOGeoDynamicMarker();
            GSOCameraState cameraState = globeControl1.Globe.CameraState;
            geoDynamicMarker.SetPosition(cameraState.Longitude, cameraState.Latitude, 0);
            geoDynamicMarker.TimerInterval = 20;
            geoDynamicMarker.Play();

            GSOMarkerStyle3D style3d = new GSOMarkerStyle3D();
            style3d.IconPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource/gif/flag1.gif";
            style3d.IconScale = 2;
            geoDynamicMarker.Style = style3d;
            newFeature.Geometry = geoDynamicMarker;
            newFeature.Name = "动态地标";

            ShowAddFeatureDlg(newFeature);
        }
     
        private void AddNewEntity(GSOGeoEntity geoEntity, string strName)
        {
            GSOFeature newFeature = new GSOFeature();
            GSOPoint3d pt = new GSOPoint3d();
            pt.X = globeControl1.Globe.CameraState.Longitude;
            pt.Y = globeControl1.Globe.CameraState.Latitude;
            pt.Z = 0;
            geoEntity.Position = pt;
            newFeature.Geometry = geoEntity;
            newFeature.Name = strName;
            ShowAddFeatureDlg(newFeature);
        }
        private void menuItemAddBoxEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoBoxEntity(), "长方体");
        }
        private void menuItemAddSphereEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoSphereEntity(), "球");
        }
        private void menuItemAddCylinderEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoCylinderEntity(), "柱");
        }

        private void menuItemAddFrustumEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoFrustumEntity(), "台");
        }

        private void menuItemAddEllipsoidEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoEllipsoidEntity(), "椭球");
        }

        private void menuItemAddEllipCylinderEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoEllipCylinderEntity(), "椭圆柱");
        }

        private void menuItemAddEllipFrustumEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoEllipFrustumEntity(), "椭圆台");
        }

        private void menuItemAddRangeEllipsoidEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoRangeEllipsoidEntity(), "缺口椭球");
        }

        private void menuItemAddRangeEllipCylinderEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoRangeEllipCylinderEntity(), "缺口椭圆柱");
        }

        private void menuItemAddRangeEllipFrustumEntity_Click(object sender, EventArgs e)
        {
            AddNewEntity(new GSOGeoRangeEllipFrustumEntity(), "缺口椭圆台");
        }

        private void buttonClearFind_Click(object sender, EventArgs e)
        {
            treeFind.Nodes.Clear();
        }      

        private void ConvertToWaterMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;
            GSOFeature feature = node.Tag as GSOFeature;
            if (feature != null && feature.Geometry!=null && feature.Geometry.Type==EnumGeometryType.GeoPolygon3D)
            {
                GSOGeoPolygon3D geoPolygon3d = (GSOGeoPolygon3D)feature.Geometry;
                GSOGeoWater geoWater=geoPolygon3d.ConvertToGeoWater();
                // 水一般都是绝对高度模式
                //geoWater.Altitude = EnumAltitudeMode.Absolute;
                feature.Delete();

                GSOFeature newFeature = new GSOFeature();
                geoWater.Play();
                newFeature.Geometry = geoWater;

                while (node!=null && node.Parent!=null)
                {
                    if (node.Parent==layerManagerNode)
                    {
                       GSOLayer layer= node.Tag as GSOLayer;
                       layer.AddFeature(newFeature);
                       RefreshTreeNodeLayerFeatureList(node);
                       break;                                            
                    }
                    if (node.Parent==myPlaceNode)
                    {
                        globeControl1.Globe.MemoryLayer.AddFeature(newFeature);
                        RefreshTreeNodeLayerFeatureList(myPlaceNode);                 
                        break;
                    }
                    node = node.Parent;
                }
                globeControl1.Refresh();               
            }
        }

        private void DrawWaterMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode featureAddLayerTreeNode = GetDestLayerFeatureAddTreeNode();
            if (featureAddLayerTreeNode == null)
            {
                MessageBox.Show("没有设置目标图层，请先设置!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GSOLayer layer = featureAddLayerTreeNode.Tag as GSOLayer;
            if (!layer.Visible || !layer.Selectable || !layer.Editable)
            {
                MessageBox.Show("请确保目标图层可视、可选、可编辑!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            globeControl1.Globe.Action = EnumAction3D.DrawWater;
            ActionToolMenuChecked(); 
        }

        private void addRouteObjectMenuItem_Click(object sender, EventArgs e)//沿线运动对象
        {
            if (globeControl1.Globe.SelectedObject==null)
            {
                MessageBox.Show("请先选择一条线!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            GSOFeature lineFeature=globeControl1.Globe.SelectedObject;
            if(lineFeature.Geometry==null || lineFeature.Geometry.Type!=EnumGeometryType.GeoPolyline3D)
            {
                MessageBox.Show("请先选择一条线!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }         
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.3ds|*.3ds|*.gcm|*.gcm|*.gse|*.gse|*.obj|*.obj||";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GSOGeoModel model=new GSOGeoModel();
                model.FilePath = dlg.FileName;

                GSOGeoDynamicRoute dynamicRoute = new GSOGeoDynamicRoute();
                dynamicRoute.ActorGeometry = model;                            

                GSORoute route = new GSORoute();
                GSOGeoPolyline3D geoline = (GSOGeoPolyline3D)lineFeature.Geometry;
                for (int i = 0; i < geoline[0].Count; i++)
                {
                    route.Add(geoline[0][i]);
                }
                route.CircleRoute = false;
                route.Speed = 30;
                route.RotateSpeed = 50;
                route.AltitudeMode = geoline.AltitudeMode;
                dynamicRoute.Route = route;

                GSOFeature feature = new GSOFeature();

                dynamicRoute.Play();
                feature.Geometry = dynamicRoute;

                GSOLabel gsoLabel = new GSOLabel();
                gsoLabel.Text = "模型测试";
                feature.Label = gsoLabel;
                globeControl1.Globe.MinModelVisibleSize = 0;

                globeControl1.Globe.MemoryLayer.AddFeature(feature);
                globeControl1.Globe.Refresh();
            }
        }

        private void MarbleSurfaceMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.MarbleVisible = !globeControl1.Globe.MarbleVisible;
            MarbleSurfaceMenuItem.Checked = globeControl1.Globe.MarbleVisible;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Layers.RemoveAll();
        }

        private void MenuItemMouseOverEventEnable_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FeatureMouseOverEnable = !globeControl1.Globe.FeatureMouseOverEnable;
            MenuItemMouseOverEventEnable.Checked = globeControl1.Globe.FeatureMouseOverEnable;
        }

        private void SceneLightSet_Click(object sender, EventArgs e)
        {
            FrmSetSceneLight dlg = new FrmSetSceneLight();
            dlg.light = globeControl1.Globe.SceneLight;
            dlg.globeControl = globeControl1;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void MenuItemEditSnapObject_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.EditSnapObject = !globeControl1.Globe.EditSnapObject;
            MenuItemEditSnapObject.Checked = !MenuItemEditSnapObject.Checked;             
        }

        
        private void SpaceHeightMeasureMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.Action != EnumAction3D.MeasureHeight)
            {
                globeControl1.Globe.Action = EnumAction3D.MeasureHeight;
                globeControl1.Globe.HeightRuler.SpaceMeasure = true;
            }
            else
            {
                if (globeControl1.Globe.HeightRuler.SpaceMeasure)
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                }
                else
                {
                    globeControl1.Globe.HeightRuler.SpaceMeasure = true;
                }
            }
            ActionToolMenuChecked();          
        }

        private void SpaceMeasureDistanceMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.Action != EnumAction3D.MeasureDistance)
            {
                globeControl1.Globe.Action = EnumAction3D.MeasureDistance;
                globeControl1.Globe.DistanceRuler.SpaceMeasure = true;
            }
            else
            {
                if (globeControl1.Globe.DistanceRuler.SpaceMeasure)
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                }
                else
                {
                    globeControl1.Globe.DistanceRuler.SpaceMeasure = true;
                }
            }
            ActionToolMenuChecked();
        }

        private void SpaceAreaMeasureMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.Action != EnumAction3D.MeasureArea)
            {
                globeControl1.Globe.Action = EnumAction3D.MeasureArea;
                globeControl1.Globe.AreaRuler.SpaceMeasure = true;
            }
            else
            {
                if (globeControl1.Globe.AreaRuler.SpaceMeasure)
                {
                    globeControl1.Globe.Action = EnumAction3D.ActionNull;
                }
                else
                {
                    globeControl1.Globe.AreaRuler.SpaceMeasure = true;
                }
            }
            ActionToolMenuChecked();
        }
        private void SpaceVisibilityAnalysisMenuItem_Click(object sender, EventArgs e)//空间通视分析
        {
            globeControl1.Globe.Action = EnumAction3D.VisibilityAnalysis;         
        }
        private void ViewshedAnalysisMenuItem_Click(object sender, EventArgs e)//可视域分析
        {
            globeControl1.Globe.Action = EnumAction3D.ViewshedAnalysis;
        }

        private void ViewEnvelopeAnalysisMenuItem_Click(object sender, EventArgs e)//可视包络分析
        {
            globeControl1.Globe.Action = EnumAction3D.ViewEnvelopeAnalysis;
        }

        private void RefreshAnalysisMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.RefreshAnalysis();
        }

        private void ClearAnalysisMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ClearAnalysis();
        }

        private void ProfileAnalysisMenuItem_Click(object sender, EventArgs e)//剖面分析
        {
            if (!ProfileAnalysisMenuItem.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolyline;
                globeControl1.Globe.TrackPolylineTool.VerticalLineVisible = true;

                ProfileAnalysisMenuItem.Checked = true;
                BaselineProfileAnalysisMenuItem.Checked = false;
                LineDigPitMenuItem.Checked = false;
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                ProfileAnalysisMenuItem.Checked = false;
                globeControl1.Globe.TrackPolylineTool.VerticalLineVisible = false;
            }

            ActionToolMenuChecked();
        }

       
        private void BaselineProfileAnalysisMenuItem_Click(object sender, EventArgs e)//基线剖面分析
        {
            if (!BaselineProfileAnalysisMenuItem.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolyline;
                globeControl1.Globe.TrackPolylineTool.VerticalLineVisible = true;

                BaselineProfileAnalysisMenuItem.Checked = true;
                ProfileAnalysisMenuItem.Checked = false;
                LineDigPitMenuItem.Checked = false;               
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                BaselineProfileAnalysisMenuItem.Checked = false;
                globeControl1.Globe.TrackPolylineTool.VerticalLineVisible = false;
            }

            ActionToolMenuChecked();
        }
        private void LineDigPitMenuItem_Click(object sender, EventArgs e)
        {
            if (!LineDigPitMenuItem.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolyline;

                LineDigPitMenuItem.Checked = true;
                ProfileAnalysisMenuItem.Checked = false;
                BaselineProfileAnalysisMenuItem.Checked = false;               
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                LineDigPitMenuItem.Checked = false;
            }

            ActionToolMenuChecked();
        }

        private void DigFillAnalysisMenuItem_Click(object sender, EventArgs e)//填挖方分析
        {
            if (!DigFillAnalysisMenuItem.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
                DigFillAnalysisMenuItem.Checked = true;
                PolygonDigPitMenuItem.Checked = false;
                NoSourceFloodSubmergeMenuItem.Checked = false;
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                DigFillAnalysisMenuItem.Checked = false;
            }

            ActionToolMenuChecked();
        }

        private void NoSourceFloodSubmergeMenuItem_Click(object sender, EventArgs e)//无源淹没分析
        {
            if (!NoSourceFloodSubmergeMenuItem.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
                NoSourceFloodSubmergeMenuItem.Checked = true;
                PolygonDigPitMenuItem.Checked = false;
                DigFillAnalysisMenuItem.Checked = false;
            }
            else 
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                NoSourceFloodSubmergeMenuItem.Checked = false;
            }

            ActionToolMenuChecked();
        }
        private void PolygonDigPitMenuItem_Click(object sender, EventArgs e)
        {
            if (!PolygonDigPitMenuItem.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
                PolygonDigPitMenuItem.Checked = true;
                DigFillAnalysisMenuItem.Checked = false;
                NoSourceFloodSubmergeMenuItem.Checked = false;
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                PolygonDigPitMenuItem.Checked = false;
            }

            ActionToolMenuChecked();
        }

        private void DigPitSettingMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetDigPit dlg = new FrmSetDigPit(m_dDigPitValue,m_bDigPitByDepth,m_dDigPitWidthAlongLine);
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                m_dDigPitValue = dlg.m_dDigPitValue;
                m_bDigPitByDepth = dlg.m_bDigPitByDepth;
                m_dDigPitWidthAlongLine = dlg.m_dDigPitWidthAlongLine;
            }
        }
        private void ClearLastPitMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.RemoveLastPit();
        }

        private void ClearPitsMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.RemoveAllPits();
        }
        
        private void FullScreen()
        {
            if (!m_bFullScreen)
            {
                SetFullScreen(true, ref m_rcOld);


                Rectangle rcControlScreen1=globeControl1.RectangleToScreen(globeControl1.Bounds);
                Rectangle rcFormScreen1 = this.RectangleToScreen(this.Bounds);
           
                this.mainMenu.Visible = false;
                expandableSplitter1.Expanded = false;
                expandableSplitter1.Visible = false;
                statusStrip1.Visible = false;
                this.ShowInTaskbar = false;
                
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                 

                FullScreenMenuItem.Checked = true;
                m_bFullScreen = true;
            }
            else
            {
                SetFullScreen(false, ref m_rcOld);
            
                this.mainMenu.Visible = true;
                expandableSplitter1.Expanded = true;
                expandableSplitter1.Visible = true;
                statusStrip1.Visible = true;
                this.ShowInTaskbar = true;

                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;                 

                m_bFullScreen = false;
                FullScreenMenuItem.Checked = false;            
            }           
        }
        private void FullScreenMenuItem_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        private void MainFrm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               case Keys.F5:
                    FullScreen();
                    break;
               case Keys.Escape:
                    // esc仅仅取消全屏
                    if (m_bFullScreen)
                    {
                        FullScreen();
                    }
                    break;
                default:
                    break;
            }          
        }
         
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        private static extern int ShowWindow(int hWnd, int _value);
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(
                int uAction,
                int uParam,
                ref Rectangle lpvParam,
                int fuWinIni
                );

        public const int SPI_SETWORKAREA = 47;
        public const int SPI_GETWORKAREA = 48;
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
        public const int SPIF_UPDATEINIFILE = 0x0001;

        /// <summary> 
        /// 设置全屏或取消全屏 
        /// </summary> 
        /// <param name="fullscreen">true:全屏 false:恢复 </param> 
        /// <param name="rectOld">设置的时候，此参数返回原始尺寸，恢复时用此参数设置恢复 </param> 
        /// <returns>设置结果 </returns> 
        public static bool SetFullScreen(bool fullscreen, ref Rectangle rectOld)
        {
            if (fullscreen)
            {
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;
                SystemParametersInfo(SPI_GETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//get 
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectFull, SPIF_UPDATEINIFILE);//set 
            }
            else
            {
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);
            }
            return true;
        }  

        private void MenuItemShowSingleModel_Click(object sender, EventArgs e)//展示单个模型
        {
            if (globeControl1.Globe.SelectedObject == null)
            {
                MessageBox.Show("请先选择一个模型!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GSOFeature modelFeature = globeControl1.Globe.SelectedObject;
            if (modelFeature.Geometry == null || modelFeature.Geometry.Type != EnumGeometryType.GeoModel)
            {
                MessageBox.Show("请先选择一个模型!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            FrmShowSingleModel dlg = new FrmShowSingleModel();
            dlg.Show(this);

            GSOFeature newFeature = modelFeature.Clone();
            newFeature.Geometry.LatLonCoord = false;
                            
            newFeature.HighLight = false;
            ((GSOGeoModel)newFeature.Geometry).SetPosition(0, 0, 0);
            dlg.plane3DControl.Plane3DScene.AddFeature(newFeature);   
        }
        GSOFeatures featuresFaGuang = new GSOFeatures();
        private void 对象闪烁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelObjectCount > 0)
            {
                featuresFaGuang.RemoveAll();
                for (int i =globeControl1.Globe.SelObjectCount - 1; i >= 0 ; i--)
                {
                    GSOFeature f = null;
                    GSOLayer layer = null;
                    globeControl1.Globe.GetSelectObject(i, out f, out layer);
                    if (f != null && f.Geometry != null)
                    {
                        featuresFaGuang.Add(f);
                    }
                    f.HighLight = false;
                    globeControl1.Globe.Refresh();
                }
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                globeControl1.Globe.Action = EnumAction3D.SelectObject;
                globeControl1.Globe.Refresh();
                timerFeatureFaGuang.Start();
            }
        }

        private void 闪烁发光ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            featuresFaGuang.RemoveAll();
            TreeNode node = treeContexMenue.Tag as TreeNode;
            GSOLayer layer = node.Parent.Tag as GSOLayer;
            GSOFeature f = node.Tag as GSOFeature;
            featuresFaGuang.Add(f);
            timerFeatureFaGuang.Start();
        }
        int count_FaGuang = 0;
        private void timerFeatureFaGuang_Tick(object sender, EventArgs e)
        {
            if (count_FaGuang < 20)
            {
                count_FaGuang++;
                if (count_FaGuang % 2 != 0)
                {
                    for (int i = 0; i < featuresFaGuang.Length; i++)
                    {
                        GSOFeature f = featuresFaGuang[i];                       
                        if (f != null && f.Geometry != null)
                        {
                            if (f.Geometry.Style != null)
                            {
                                ((GSOStyle3D)f.Geometry.Style).UsingBlur = true;
                            }
                            else
                            {
                                switch (f.Geometry.Type)
                                {
                                    case EnumGeometryType.GeoPoint3D:
                                    case EnumGeometryType.GeoDynamicPoint3D:
                                        {
                                            f.Geometry.Style = new GSOPointStyle3D();
                                        }
                                        break;
                                    case EnumGeometryType.GeoMarker:
                                    case EnumGeometryType.GeoDynamicMarker:
                                        {

                                            f.Geometry.Style = new GSOMarkerStyle3D();                                             
                                        }
                                        break;
                                    case EnumGeometryType.GeoPolyline3D:
                                        {
                                            f.Geometry.Style = new GSOLineStyle3D();                                            
                                        }
                                        break;
                                    case EnumGeometryType.GeoPolygon3D:
                                    case EnumGeometryType.GeoWater:
                                        {
                                            f.Geometry.Style = new GSOPolygonStyle3D();                                            
                                        }
                                        break;
                                    default:
                                        {
                                            f.Geometry.Style = new GSOEntityStyle3D();
                                        }
                                        break;
                                }                                
                                if (f.Geometry.Style != null)
                                {
                                    ((GSOStyle3D)f.Geometry.Style).UsingBlur = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < featuresFaGuang.Length; i++)
                    {
                        GSOFeature f = featuresFaGuang[i]; 
                        if (f != null && f.Geometry != null)
                        {
                            if (f.Geometry.Style != null)
                            {
                                ((GSOStyle3D)f.Geometry.Style).UsingBlur = false;
                            }
                            else
                            {
                                switch (f.Geometry.Type)
                                {
                                    case EnumGeometryType.GeoPoint3D:
                                    case EnumGeometryType.GeoDynamicPoint3D:
                                    case EnumGeometryType.GeoMarker:
                                    case EnumGeometryType.GeoDynamicMarker:
                                        {

                                            f.Geometry.Style = new GSOMarkerStyle3D();
                                        }
                                        break;
                                    case EnumGeometryType.GeoPolyline3D:
                                        {
                                            f.Geometry.Style = new GSOLineStyle3D();
                                        }
                                        break;
                                    case EnumGeometryType.GeoPolygon3D:
                                    case EnumGeometryType.GeoWater:
                                        {
                                            f.Geometry.Style = new GSOPolygonStyle3D();
                                        }
                                        break;
                                    default:
                                        {
                                            f.Geometry.Style = new GSOEntityStyle3D();
                                        }
                                        break;
                                }       
                                if (f.Geometry.Style != null)
                                {
                                    ((GSOStyle3D)f.Geometry.Style).UsingBlur = false;
                                }
                            }
                        }
                    }
                }
                globeControl1.Globe.Refresh();
            }
            else
            {
                timerFeatureFaGuang.Stop();
                count_FaGuang = 0;
            }
        }
        
        private void ShowSingleModelTreeMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeContexMenue.Tag as TreeNode;
            GSOFeature feature = node.Tag as GSOFeature;
            if (feature != null && feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoModel)
            {
                FrmShowSingleModel dlg = new FrmShowSingleModel();
                dlg.Show(this);

                GSOFeature newFeature = feature.Clone();
                newFeature.Geometry.LatLonCoord = false;
                newFeature.HighLight = false;
                ((GSOGeoModel)newFeature.Geometry).SetPosition(0, 0, 0);

                dlg.plane3DControl.Plane3DScene.AddFeature(newFeature);
            }
        }

        private void SelLevel1MenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.SelLevel = 0;
            ActionToolMenuChecked();
        }       

        private void SelLevel2MenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.SelLevel = 1;
            ActionToolMenuChecked();
        }

        private void SelLevel3MenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.SelLevel = 2;
            ActionToolMenuChecked();
        }
        private void MenuItemLayerVisibleAlt_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            GSOLayer layer = node.Tag as GSOLayer;
            if (layer != null)
            {
                FrmSetLayerVisibleAltitude dlg = new FrmSetLayerVisibleAltitude();
                dlg.m_dMaxVisibleAlt = layer.MaxVisibleAltitude;
                dlg.m_dMinVisibleAlt = layer.MinVisibleAltitude;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    layer.MaxVisibleAltitude = dlg.m_dMaxVisibleAlt;
                    layer.MinVisibleAltitude = dlg.m_dMinVisibleAlt;
                }
            }
        }

        private void MenuItemObjectVisibleDist_Click(object sender, EventArgs e)
        {             
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            GSOLayer layer = node.Tag as GSOLayer;
            if (layer!=null)
            {
                FrmSetObjectVisibleDistance dlg=new FrmSetObjectVisibleDistance() ;
                dlg.m_dMaxVisibleDist = layer.ObjectMaxVisibleDistance;
                dlg.m_dMinVisibleDist = layer.ObjectMinVisibleDistance;
                if (dlg.ShowDialog()==DialogResult.OK)
                {
                    layer.ObjectMaxVisibleDistance= dlg.m_dMaxVisibleDist;
                    layer.ObjectMinVisibleDistance= dlg.m_dMinVisibleDist;
                }
            }              
        }

        private void MenuItemVisiblePixelSize_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            GSOLayer layer = node.Tag as GSOLayer;
            if (layer != null)
            {
                FrmSetObjectVisiblePixelSize dlg = new FrmSetObjectVisiblePixelSize();
                dlg.m_dMaxVisiblePixelSize = layer.ObjectMaxVisiblePixelSize;
                dlg.m_dMinVisiblePixelSize = layer.ObjectMinVisiblePixelSize;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    layer.ObjectMaxVisiblePixelSize = dlg.m_dMaxVisiblePixelSize;
                    layer.ObjectMinVisiblePixelSize = dlg.m_dMinVisiblePixelSize;
                }
            }
        }

        private void MyPlaceVisibleDistMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = (GSOLayer)globeControl1.Globe.MemoryLayer;
            if (layer != null)
            {
                FrmSetObjectVisibleDistance dlg = new FrmSetObjectVisibleDistance();
                dlg.m_dMaxVisibleDist = layer.ObjectMaxVisibleDistance;
                dlg.m_dMinVisibleDist = layer.ObjectMinVisibleDistance;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    layer.ObjectMaxVisibleDistance = dlg.m_dMaxVisibleDist;
                    layer.ObjectMinVisibleDistance = dlg.m_dMinVisibleDist;
                }
            }        
        }

        private void MyPlaceVisiblePixelSizeMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = (GSOLayer)globeControl1.Globe.MemoryLayer;
            if (layer != null)
            {
                FrmSetObjectVisiblePixelSize dlg = new FrmSetObjectVisiblePixelSize();
                dlg.m_dMaxVisiblePixelSize = layer.ObjectMaxVisiblePixelSize;
                dlg.m_dMinVisiblePixelSize = layer.ObjectMinVisiblePixelSize;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    layer.ObjectMaxVisiblePixelSize = dlg.m_dMaxVisiblePixelSize;
                    layer.ObjectMinVisiblePixelSize = dlg.m_dMinVisiblePixelSize;
                }
            }
        }

        private void LayerOpaqueMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            GSOLayer layer = node.Tag as GSOLayer;
            if (layer != null)
            {
                FrmSetLayerOpaque dlg = new FrmSetLayerOpaque();
                dlg.globe = globeControl1.Globe ;
                dlg.layer = layer;
                dlg.Show(this);
            }
        }

        private void MyPlaceLayerOpaqueMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = (GSOLayer)globeControl1.Globe.MemoryLayer;
            if (layer != null)
            {
                FrmSetLayerOpaque dlg = new FrmSetLayerOpaque();
                dlg.globe = globeControl1.Globe;
                dlg.layer = layer;
                dlg.Show(this);
            }
        }

        private void MoveModelLayerMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdjustLayer frm = new FrmAdjustLayer(globeControl1);
           
            frm.Show(this);
            
        }

        private void menuItemElevateLayerModels_Click(object sender, EventArgs e)
        {
            FrmElevateLayer frm = new FrmElevateLayer(globeControl1);
            frm.Show(this);
        }

        private void ConvertToPowerLineMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature fLineToPowerLine = globeControl1.Globe.SelectedObject;
            if (fLineToPowerLine != null)
            {
                if (fLineToPowerLine.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                {
                    FrmLineToPowerLine fm = new FrmLineToPowerLine(globeControl1, fLineToPowerLine);
                    fm.Show(this);
                }
                else
                {
                    MessageBox.Show("请选中线对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("请先选中一条线对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void panelGlobeControl_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("请选中线对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void fullExtentMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FullExtent();
        }

        private void pauseFlyMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.PauseFly();
        }

        private void continueFlyMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ContinueFly();
        }

        private void rmuPauseFlyMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.PauseFly();
        }

        private void rmuContinueFlyMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.ContinueFly();
        }

        private void rmuStopFlyMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.StopFly();
        }

        private void rmuFullExtentMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FullExtent();
        }

        private void rmuRotateEyeFlyMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FlyAroundEye();
        }

        private void rmuRotateCenterFlyMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.FlyAroundCenter();
        }

        private void UnderGroundFloorMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnderGroundFloorSetting dlg = new FrmUnderGroundFloorSetting();
            dlg.m_globe = globeControl1.Globe;
            dlg.Show(this);
        }

        private void featureLabelMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelectedObject == null)
            {
                MessageBox.Show("请先选中一个待标注要素！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmLabel frm = new FrmLabel(globeControl1);
                frm.ShowDialog();
            }
        }

        private void underGroundLockedMenuItem_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.IsUnderGroundLocked = !globeControl1.Globe.IsUnderGroundLocked;
            underGroundLockedMenuItem.Checked = globeControl1.Globe.IsUnderGroundLocked;
            globeControl1.Refresh();
        }

        private object AddTerrainData(string strDataPath)
        {
            object objRes = null;
            GSOTerrain terrain = globeControl1.Globe.Terrains.Add(strDataPath);
            objRes = terrain;
            if (terrain != null)
            {
                CheckDatasetGeoReference(terrain.Dataset);
                 
                TreeNode node = new TreeNode();
                node.Tag = terrain;
                node.Text = terrain.Caption;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Checked = terrain.Visible;
                // 注意用insert不要用add，因为后加入的图层在上层
                // terrainManagerNode.Nodes.Add(node);
                terrainManagerNode.Nodes.Insert(0, node);
            }
            terrainManagerNode.Expand();
            RefreshDataTree();
            return objRes;

        }
        

        private void MenuItem2DObjMouseOverEnable_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Object2DMouseOverEnable = !globeControl1.Globe.Object2DMouseOverEnable;
            MenuItem2DObjMouseOverEnable.Checked = !MenuItem2DObjMouseOverEnable.Checked;            
        }

        private void rmuFullScreenMenuItem_Click(object sender, EventArgs e)
        {
            FullScreen();
            rmuFullScreenMenuItem.Checked = !rmuFullScreenMenuItem.Checked;
        }

        private void rmuCameraNavigation_Click(object sender, EventArgs e)
        {
            ActionBrowseMenu_Click(sender, e);
            globeControl1.Globe.CameraMode = EnumCameraMode.Navigation;
            CameraNavigationMenu.Checked = true;
            CameraWalkMenu.Checked = false;
            CameraUnderGroundMenu.Checked = false;  
        }       

        private void 投影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProject frm = new FrmProject();
            frm.Show(this);
        }

        //批量生成模型
        private void menuAddModelBat_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.Layers.Count <= 0)
            {
                MessageBox.Show("请先添加图层！");
                return;
            }
            FrmBatchCreateModel frm = new FrmBatchCreateModel(globeControl1);
            frm.ShowDialog();            
        }

        //批量生成管线
        private void menuLine2PipelineModel_Click(object sender, EventArgs e)
        {
            FrmBatchCreatePipeline frm = new FrmBatchCreatePipeline(globeControl1);
            frm.ShowDialog();
        }

        private void 批量生成管孔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBatchCreatePore frm = new FrmBatchCreatePore(globeControl1);
            frm.ShowDialog();
        }

        private void 批量生成管沟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBatchCreatePipeDitch frm = new FrmBatchCreatePipeDitch(globeControl1);
            frm.ShowDialog();
        }

        private void 批量修改颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBatchUpadateColor frm = new FrmBatchUpadateColor(globeControl1);
            frm.Show(this);
        }
        private void 批量修改字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBatchUpadateFontOfMarkers frm = new FrmBatchUpadateFontOfMarkers(globeControl1);
            frm.Show(this);
        }
        private void 批量修改字段值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBatchUpdateFieldValue frm = new FrmBatchUpdateFieldValue(globeControl1);
            frm.Show(this);
        }
       
        private void 批量修改要素集模型路径toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmBacthUpdateModelPath frm = new FrmBacthUpdateModelPath(globeControl1);
            frm.ShowDialog();
        }

        private void 新建数据库数据集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorldGIS.Forms.FrmNewDBFeatureDataset frm = new WorldGIS.Forms.FrmNewDBFeatureDataset(globeControl1);
            frm.ShowDialog();
        }

        //shp格式文件转换为lgd或者kml格式文件
        private void shp2KMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorldGIS.Forms.FrmShp2KML frm = new WorldGIS.Forms.FrmShp2KML(globeControl1);
            frm.ShowDialog();
        }

        private void 字段编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            GSOLayer layer = node.Tag as GSOLayer;
            if (layer != null)
            {
                FrmEditLayerAttributes frm_editor = new FrmEditLayerAttributes(layer, globeControl1);
                frm_editor.Show(this);
            }
        }

        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;
            GSOLayer layer = node.Tag as GSOLayer;
            if (layer != null)
            {
                GSOFeatures features = layer.GetAllFeatures();
                if(features == null)
                {
                    MessageBox.Show("图层中对象总数为null！","提示");
                    return;
                }
                FrmEditLayerAttributesByTable frm_editor = FrmEditLayerAttributesByTable.GetForm(layer,features, globeControl1);
                frm_editor.SetDataTable();
                if (!frm_editor.isShow)
                {
                    return;
                }
                if (!frm_editor.isShowFirst)
                {
                    frm_editor.Show(this);
                }
            }
        }

        private bool addfitflag =false;
        private void 添加管件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addfitflag = true;
        }

        private void 管线对接设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetPipelineJointParams dlg = new FrmSetPipelineJointParams(globeControl1.Globe);
            dlg.ShowDialog();
        }

        private void 对接选中管线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelObjectCount < 2)
            {
                MessageBox.Show("对不起，请至少选中2个对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            globeControl1.Globe.ButtjointSelPipeline();
        }

        private void 对接选中图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPipelineLayerButtjoint dlg = new FrmPipelineLayerButtjoint(globeControl1);
            dlg.ShowDialog();
        }

        private void 生成连接管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelObjectCount < 2)
            {
                MessageBox.Show("对不起，请至少选中2个对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            globeControl1.Globe.InsertJointPipeline(false);
        }

        private void 选中节点添加模型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(globeControl1.Globe.HasSelNode)
            {
                GSOPoint3d pt3d = globeControl1.Globe.SelNodePos;
                
                WorldGIS.Forms.FrmAddPipeFitting frm = new WorldGIS.Forms.FrmAddPipeFitting(globeControl1, pt3d,globeControl1.Globe.DestLayerFeatureAdd);
                frm.Show(this);
            }            
        }

        private void 取消选中对接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelObjectCount < 1)
            {
                MessageBox.Show("没有选中的对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            globeControl1.Globe.CancelSelPipelineJoint(true, true);
        }

        private void 取消整个图层对接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorldGIS.Forms.FrmCancelLayerjoint frm = new WorldGIS.Forms.FrmCancelLayerjoint(globeControl1);
            frm.ShowDialog();
        }

        private void 复制数据库要素集结构ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }            
            WorldGIS.Forms.FrmCloneFeatureDatasetStructure frm = new WorldGIS.Forms.FrmCloneFeatureDatasetStructure(globeControl1);
            frm.ShowDialog();
        }

        private void 管孔方沟入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            WorldGIS.Forms.FrmMultiPipelineModelDB frm = new WorldGIS.Forms.FrmMultiPipelineModelDB(globeControl1);
            frm.ShowDialog();
        }

        private void 工井入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            WorldGIS.Forms.FrmAddWellShp frm = new WorldGIS.Forms.FrmAddWellShp(globeControl1);
            frm.ShowDialog();
        }

        private void 排水入库ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            WorldGIS.Forms.FrmPaiShui2DB frm = new WorldGIS.Forms.FrmPaiShui2DB(globeControl1);
            frm.ShowDialog();
        }
        //阀门入库
        private void 阀门入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            WorldGIS.Forms.FrmAddValve frm = new WorldGIS.Forms.FrmAddValve(globeControl1);
            frm.ShowDialog();
        }

        private void 雨水篦子入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            Forms.FrmAddYuBiZiShp frm = new WorldGIS.Forms.FrmAddYuBiZiShp(globeControl1);
            frm.ShowDialog();
        }

        private void 管线入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            WorldGIS.Forms.FrmPipelineModelDB frm = new WorldGIS.Forms.FrmPipelineModelDB(globeControl1);
            frm.ShowDialog();
        }

        //创建拓扑
        private void 创建拓扑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmCreateGenTopo frm = new FrmCreateGenTopo(globeControl1);
            frm.Show(this);
        }       

        //流向显示
        private void tooltripItemFlow_Click(object sender, EventArgs e)
        {
            FrmAnalysisFlow flow = new FrmAnalysisFlow(globeControl1);
            flow.Show();
        }
        //复制数据库要素集到另一数据库中
        private void toolstripItem_CopyDataSet_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmCopyFeatureDataset CopyFeatureDataSet = new FrmCopyFeatureDataset(globeControl1);
            CopyFeatureDataSet.Show();
        }
        //合并数据库要素集
        private void tooltripItem_UnionDataSet_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmUnionFeatureDataset frm = new FrmUnionFeatureDataset(globeControl1);
            frm.Show();
        }
        
        private void attributeMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }

            GSOFeature feature = (GSOFeature)layerTree.SelectedNode.Tag;
            GSOLayer layer = (GSOLayer)layerTree.SelectedNode.Parent.Tag;
            FrmAtrributeMapping1 attriMap = new FrmAtrributeMapping1(globeControl1,layer,feature);
            attriMap.Show(this);
        }

        private void 修改数据库管线颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmBatchUpdatePipelineColor form = new FrmBatchUpdatePipelineColor(globeControl1);
            form.Show(this);            
        }

        private void 查看管线属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature feature = globeControl1.Globe.SelectedObject;
            if (feature != null)
            {
                FrmShowAtrributesByTable attriMap = new FrmShowAtrributesByTable(globeControl1, feature);
                attriMap.Show(this);
            }
        }

        private void 种树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlantTrees plantTree = new FrmPlantTrees(globeControl1);
            plantTree.Show(this);
        }

        private void 改变图层风格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(layerTree.SelectedNode.Text);
            FrmUpdateLayoutColor updateLayoutColor = new FrmUpdateLayoutColor(globeControl1,layer);
            updateLayoutColor.Show(this);
        }
        
        private void globeControl1_AfterNetLayerAddEvent(object sender, AfterNetLayerAddEventArgs e)
        {
            RefreshDataTree();
            RefreshLayerAndTerrainTree();
            globeControl1.Globe.Refresh();
        }
        int count = 0;
        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = (TreeNode)layerNodeContexMenu.Tag;
            if (node != null)
            {
                string name = node.Text;
                string path = "";
                string type = "";
                double opaque = 0.0d;
                bool isEdit = false;
                
                if (node.Parent == layerManagerNode)
                {
                    GSOLayer layer = (GSOLayer)node.Tag;
                    if (layer != null)
                    {
                        if (layer.Dataset != null && layer.Dataset.DataSource != null)
                        {
                            GSODataSource ds = layer.Dataset.DataSource;
                            if (ds.Type == EnumDataSourceType.SqlServer)
                            {
                                path = ds.Name.Substring(0, ds.Name.IndexOf("_"));
                            }
                            else if (ds.Type == EnumDataSourceType.Oracle)
                            {
                                path = ds.Name.Substring(0, ds.Name.IndexOf("/"));
                            }
                        }
                        else
                        {
                            path = layer.Name;
                        }
                        GSOFeatures feats = new GSOFeatures();
                        count = 0;
                        GetReallyFeature(layer.GetAllFeatures());
                        
                        type = layer.Type.ToString();
                        opaque = layer.Opaque;
                        isEdit = layer.Editable;

                        MessageBox.Show("图层名称：" + name + "\n\n路径：" + path + "\n\n类型：" + type
                            + "\n\n不透明度：" + opaque.ToString() + "\n\n可编辑：" + isEdit.ToString()
                            + "\n\n共有 " + count.ToString() + " 条记录", "属性", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void GetReallyFeature(GSOFeatures features)
        {
            if (features != null && features.Length > 0)
            {
                for (int i = 0; i < features.Length; i++)
                {
                    if (features[i].Type == EnumFeatureType.FeatureFolder)
                    {
                        GetReallyFeature(((GSOFeatureFolder)features[i]).Features);
                    }
                    else
                    {                       
                        count++;                        
                    }
                }
            }
        }

        private void 属性ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (featureMouseRightClickAttr != null)
            {
                LookSelobjAttribute(featureMouseRightClickAttr); 
            }
        }

        private void 反转方向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ReverseDirection();
        }
        void  ReverseDirection()
        { 
            GSOFeature feature = globeControl1.Globe.SelectedObject;
            if (feature == null)
            {
                MessageBox.Show("没有选中对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GSOGeoPolyline3D geopolyline = feature.Geometry as GSOGeoPolyline3D;
            if (geopolyline == null || feature.Geometry.Style == null)
            {
                MessageBox.Show("对象无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GSOPipeLineStyle3D pipeLineStyle = feature.Geometry.Style as GSOPipeLineStyle3D;
            if (pipeLineStyle == null)
            {
                MessageBox.Show("对象无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GSOPipeJointParam newTailParam = null;
            GSOPipeJointParam newHeadParam = null;
            //先调换接头
            if (pipeLineStyle.HeadJointParam != null)
            {
                newTailParam = new GSOPipeJointParam(pipeLineStyle.HeadJointParam);
            }
            if (pipeLineStyle.TailJointParam != null)
            {
                newHeadParam = new GSOPipeJointParam(pipeLineStyle.TailJointParam);
            }
            pipeLineStyle.HeadJointParam = newHeadParam;
            pipeLineStyle.TailJointParam = newTailParam;
            //调换线数据
            geopolyline.Reverse();
            pipeLineStyle.ArrowVisible = false;
            pipeLineStyle.ArrowVisible = true;

            globeControl1.Refresh();
        }        

        private void 管线导出CADToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TreeNode node =  (TreeNode)layerNodeContexMenu.Tag;
            if (node == null)
            {
                MessageBox.Show("请在左侧节点集中选择要导出的图层", "提示");
                return;
            }
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption(node.Text.Trim());            
            string strProjectName = Utility.GetProjectName();            
            if (strProjectName != "")
            {
                layer.Dataset.ImportProjectionRefFromProj4(strProjectName);

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "*.dxf|*.dxf";
                dlg.FileName = layer.Caption;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    GSOLayer newlayer = globeControl1.Globe.Layers.Add(dlg.FileName);
                    if (layer.GetAllFeatures().Length <= 0)
                    {
                        MessageBox.Show("要导出的图层为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                    {
                        GSOFeature feature = layer.GetFeatureByCustomID(i);
                        if (feature != null && feature.Geometry != null)
                        {
                            if (feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                            {
                                newlayer.AddFeature(feature);
                            }
                        }
                    }
                    if (newlayer.GetAllFeatures().Length > 0)
                    {
                        newlayer.SaveAs(dlg.FileName);
                        MessageBox.Show("导出CAD完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void 合并lgd和kml图层toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmMergeLayerLgdAndKml merge = new FrmMergeLayerLgdAndKml(globeControl1);
            merge.Show(this);
        }

        private void 选中管线缩进接头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature feature = globeControl1.Globe.SelectedObject;
            if (feature == null)
            {
                MessageBox.Show("没有选中的对象！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (feature.Geometry == null || feature.Geometry.Style == null)
            {
                MessageBox.Show("对象无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GSOPipeLineStyle3D pipeLineStyle = feature.Geometry.Style as GSOPipeLineStyle3D;
            if (pipeLineStyle == null)
            {
                MessageBox.Show("对象无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmDecjointPipeline dlg = new FrmDecjointPipeline(globeControl1.Globe, pipeLineStyle);
            dlg.Show(this);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)//回退
        {
            globeControl1.Globe.UnDoEdit();
        }

        private void 前进ToolStripMenuItem_Click(object sender, EventArgs e)//前进
        {
            globeControl1.Globe.ReDoEdit();
        }

        private void 烟火ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            newFeature = AddFireSmoke();
            ShowAddFeatureDlg(newFeature);
        }

        private void 火苗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            newFeature = AddFire();
            ShowAddFeatureDlg(newFeature);
        }

        private void 烟花ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            newFeature = AddFireSpark();
            ShowAddFeatureDlg(newFeature);
        }

        private void 水柱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            newFeature = AddWaterLine();
            ShowAddFeatureDlg(newFeature);
        }

        private void 喷泉MenuItemAddFountain_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature = new GSOFeature();
            newFeature = AddFountain();
            ShowAddFeatureDlg(newFeature);
        }

        private void 粒子系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOFeature newFeature1 = new GSOFeature();
            newFeature1 = AddFireSmoke();
            GSOFeature newFeature2 = new GSOFeature();
            newFeature2 = AddFire();
            GSOFeature newFeature3 = new GSOFeature();
            newFeature3 = AddFireSpark();
            GSOFeature newFeature4 = new GSOFeature();
            newFeature4 = AddWaterLine();
            GSOFeature newFeature5 = new GSOFeature();
            newFeature5 = AddFountain();

            TreeNode featureAddLayerTreeNode = GetDestLayerFeatureAddTreeNode();
            if (featureAddLayerTreeNode == null)
            {
                MessageBox.Show("添加失败！没有设置目标图层，请先设置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 先添加到图层中，这样可以预览效果
            GSOLayer featureAddLayer = (GSOLayer)featureAddLayerTreeNode.Tag;
            featureAddLayer.AddFeature(newFeature1);
            featureAddLayer.AddFeature(newFeature2);
            featureAddLayer.AddFeature(newFeature3);
            featureAddLayer.AddFeature(newFeature4);
            featureAddLayer.AddFeature(newFeature5);
            globeControl1.Refresh();
        }

        //烟火
        private GSOFeature AddFireSmoke()
        {
            // 烟火示例
            string strResPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource";

            //  烟火粒子示例,由三个发射器构成
            GSOGeoParticle geoParticle = new GSOGeoParticle();
            geoParticle.SetPosition(116.31, 39.84, 0); // 添加到这个经纬度位置

            GSORingParticleEmitter emitter = new GSORingParticleEmitter();
            emitter.TexturePath = strResPath + "/ParticleImage/烟1111111111111.png";

            emitter.SetSizeFix(20, 20); //20,20
            emitter.VelFix = 70; //70
            emitter.AccFix = -3.0f; //-0.3f
            emitter.AngleXYFix = 0;
            emitter.AngleXYRnd = 180;

            emitter.AngleXZFix = 85;
            emitter.AngleXZRnd = 5;

            emitter.InnerRadius = 0;
            emitter.OuterRadius = 30;

            emitter.LifeFix = 2.0f;
            emitter.LifeRnd = 1.0f;

            emitter.RotFix = 0;
            emitter.RotRnd = 10;

            emitter.RotVelFix = 0;
            emitter.RotVelRnd = 180;

            emitter.EmitPerSec = 60;
            emitter.ColorRndStart = Color.Black;
            emitter.ColorRndEnd = Color.Black;

            emitter.IsLumAdded = false;

            GSOScaleParticleEffector effector1 = new GSOScaleParticleEffector();
            effector1.SetScale(4, 4);  //4,4
            effector1.StartTime = 0; 
            effector1.EndTime = 1.8f;

            // 添加效果器
            emitter.AddEffector(effector1);

            GSOColorParticleEffector effector2 = new GSOColorParticleEffector();
            effector2.SetColorChanged(0.6f, 0.6f, 0.6f, 0);
            effector2.StartTime = 0;
            effector2.EndTime = -1; // 负数表示整个粒子生命结束

            emitter.AddEffector(effector2);

            GSOColorParticleEffector effector3 = new GSOColorParticleEffector();
            effector3.SetColorChanged(0, 0, 0, -1);
            effector3.StartTime = 0.5f;
            effector3.StartTimeType = EnumEffectorTimeType.ToDeadSeconds; // 距离粒子生命结束0.5秒
            effector3.EndTime = 0;
            effector3.EndTimeType = EnumEffectorTimeType.ToDeadSeconds; // 距离粒子生命结束0秒

            emitter.AddEffector(effector3);

            GSORingParticleEmitter emitter2 = new GSORingParticleEmitter();

            emitter2.TexturePath = strResPath + "/ParticleImage/fire_final_2.png";

            emitter2.SetSizeFix(8, 8); //8,8
            emitter2.VelFix = 30;    //30

            emitter2.GravityAcc = -3.0f; // 重力加速度 -3.0

            emitter2.AngleXYFix = 0;
            emitter2.AngleXYRnd = 180;

            emitter2.AngleXZFix = 90;
            emitter2.AngleXZRnd = 5;

            emitter2.InnerRadius = 0;
            emitter2.OuterRadius = 30; //30

            emitter2.LifeFix = 2.0f;
            emitter2.LifeRnd = 0.5f;

            emitter2.RotFix = 0;
            emitter2.RotRnd = 30;

            emitter2.RotVelFix = 0;
            emitter2.RotVelRnd = 60;

            emitter2.EmitPerSec = 300;

            emitter2.ColorRndStart = Color.FromArgb(255, 255, (int)(0.38 * 255), 0);
            emitter2.ColorRndEnd = Color.FromArgb(255, 255, (int)(0.404 * 255), 0);

            GSOColorParticleEffector effector4 = new GSOColorParticleEffector();
            effector4.SetColorChanged(-1, -1, -1, 0);
            effector4.StartTime = 1;
            effector4.StartTimeType = EnumEffectorTimeType.ToDeadSeconds; // 距离粒子生命结束0.5秒
            effector4.EndTime = 0;
            effector4.EndTimeType = EnumEffectorTimeType.ToDeadSeconds; // 距离粒子生命结束0秒
            emitter2.AddEffector(effector4);

            GSORingParticleEmitter emitter3 = (GSORingParticleEmitter)emitter2.Clone();
            emitter3.TexturePath = strResPath + "/ParticleImage/fire_final_1.png";
            emitter3.GravityAcc = -2.0f; // 重力加速度 -2.0f

            // 将三个发射器添加到粒子对象中
            geoParticle.AddEmitter(emitter);
            geoParticle.AddEmitter(emitter2);
            geoParticle.AddEmitter(emitter3);

            geoParticle.Play();
            GSOFeature feature = new GSOFeature();

            feature.Geometry = geoParticle;

            //globeControl1.Globe.MemoryLayer.AddFeature(feature);
            globeControl1.Globe.FlyToFeature(feature);

            return feature;
        }

        // 烟花
        private GSOFeature AddFireSpark()
        {
            // 烟火示例

            string strResPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource";

            //  烟火粒子示例,由三个发射器构成
            GSOGeoParticle geoParticle = new GSOGeoParticle();
            geoParticle.SetPosition(116.312, 39.84, 200); // 添加到这个经纬度位置
            geoParticle.AltitudeMode = EnumAltitudeMode.RelativeToGround;

            GSORingParticleEmitter emitter = new GSORingParticleEmitter();
            emitter.TexturePath = strResPath + "/ParticleImage/flare3.png";

            emitter.SetSizeFix(8, 8);
            emitter.VelFix = 70;
            emitter.AccFix = -2.0f;
            emitter.GravityAcc = 9.8f; // 重力加速度
            emitter.AngleXYFix = 0;
            emitter.AngleXYRnd = 180;

            emitter.AngleXZFix = 0;
            emitter.AngleXZRnd = 90;

            emitter.LifeFix = 5.0f;
            emitter.LifeRnd = 0.0f;

            emitter.EmitPerSec = 99999;
            emitter.MaxCount = 300;

            // 采用线性插值生成粒子的初始颜色
            emitter.ColorRndStart = Color.White;
            emitter.ColorRndEnd = Color.Red;

            emitter.IsLumAdded = true; // 例子颜色亮度叠加

            GSOIncreaseSizeParticleEffector effector1 = new GSOIncreaseSizeParticleEffector();
            effector1.SetIncreasePerSecond(-2, -2);
            effector1.StartTime = 0;
            effector1.EndTime = -1; // 负数表示整个粒子生命结束

            // 添加效果器
            emitter.AddEffector(effector1);

            GSOColorParticleEffector effector2 = new GSOColorParticleEffector();
            effector2.SetColorChanged(0, 0, 0, -1);
            effector2.StartTime = 0.8f;
            effector2.EndTime = 1.5f;
            emitter.AddEffector(effector2);

            // 将三个发射器添加到粒子对象中
            geoParticle.AddEmitter(emitter);

            geoParticle.Play();
            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoParticle;
            globeControl1.Globe.FlyToFeature(feature);

            return feature;
        }

        // 添加火苗
        private GSOFeature AddFire()
        {
            // 烟火示例
            string strResPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource";

            //  烟火粒子示例,由三个发射器构成
            GSOGeoParticle geoParticle = new GSOGeoParticle();
            geoParticle.SetPosition(116.313, 39.84, 200); // 添加到这个经纬度位置
            geoParticle.AltitudeMode = EnumAltitudeMode.RelativeToGround;

            GSORingParticleEmitter emitter = new GSORingParticleEmitter();
            emitter.TexturePath = strResPath + "/ParticleImage/flare.png";

            emitter.SetSizeFix(8, 8);
            emitter.VelFix = 25;
            emitter.VelRnd = 20;

            emitter.AngleXYFix = 0;
            emitter.AngleXYRnd = 180;

            emitter.AngleXZFix = 90;
            emitter.AngleXZRnd = 0;

            emitter.LifeFix = 0.5f;
            emitter.LifeRnd = 0.0f;

            emitter.RotFix = 0;
            emitter.RotRnd = 0;

            emitter.RotVelFix = 0;
            emitter.RotVelRnd = 0;

            emitter.EmitPerSec = 100;

            // 采用线性插值生成粒子的初始颜色
            emitter.ColorRndStart = Color.White;
            emitter.ColorRndEnd = Color.Red;


            GSOColorParticleEffector effector2 = new GSOColorParticleEffector();
            effector2.SetColorChanged(0, -1, -1, 0);
            effector2.StartTime = 0.0f;
            effector2.EndTime = -1.0f;
            emitter.AddEffector(effector2);

            // 将三个发射器添加到粒子对象中
            geoParticle.AddEmitter(emitter);

            geoParticle.Play();
            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoParticle;
            globeControl1.Globe.FlyToFeature(feature);

            return feature;
        }

        // 添加喷泉
        private GSOFeature AddFountain()
        {
            string strResPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource";

            GSOGeoParticle geoParticle = new GSOGeoParticle();
            geoParticle.SetPosition(116.314, 39.84, 0); // 添加到这个经纬度位置

            GSOPointParticleEmitter emitter = new GSOPointParticleEmitter();
            emitter.TexturePath = strResPath + "/ParticleImage/test.png";

            emitter.SetSizeFix(0.5f, 2);
            emitter.VelFix = 10;
            emitter.VelRnd = 2;

            emitter.GravityAcc = 9.8f;
            emitter.AngleXYFix = 0;
            emitter.AngleXYRnd = 180;

            emitter.AngleXZFix = 88;
            emitter.AngleXZRnd = 2;

            emitter.LifeFix = 5.0f;
            emitter.LifeRnd = 1.0f;

            emitter.RotFix = 0;
            emitter.RotRnd = 0;

            emitter.RotVelFix = 0;
            emitter.RotVelRnd = 0;

            emitter.EmitPerSec = 1000;
            emitter.ColorRndStart = Color.FromArgb(33, 255, 255, 255);
            emitter.ColorRndEnd = Color.FromArgb(11, 255, 255, 255);
            emitter.IsLumAdded = false;

            // 将三个发射器添加到粒子对象中
            geoParticle.AddEmitter(emitter);

            geoParticle.Play();
            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoParticle;
            globeControl1.Globe.FlyToFeature(feature);

            return feature;
        }

        // 添加水柱
        private GSOFeature  AddWaterLine()
        {
            string strResPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Resource";

            GSOGeoParticle geoParticle = new GSOGeoParticle();
            geoParticle.SetPosition(116.308, 39.84, 0); // 添加到这个经纬度位置

            GSOPointParticleEmitter emitter = new GSOPointParticleEmitter();

            emitter.TexturePath = strResPath + "/ParticleImage/drop3.png";

            geoParticle.TimerInterval = 1;

            emitter.SetSizeFix(2.0f, 2.0f);

            emitter.VelFix = 50;
            emitter.VelRnd = 2;

            emitter.GravityAcc = 9.8f;
            emitter.AngleXYFix = 0;
            emitter.AngleXYRnd = 2;

            emitter.AngleXZFix = 60;
            emitter.AngleXZRnd = 2;

            emitter.LifeFix = 5.0f;
            emitter.LifeRnd = 1.0f;

            emitter.RotFix = 0;
            emitter.RotRnd = 0;

            emitter.RotVelFix = 0;
            emitter.RotVelRnd = 0;

            emitter.EmitPerSec = 1500;

            emitter.ColorRndStart = Color.FromArgb(100, 222, 222, 222);
            emitter.ColorRndEnd = Color.FromArgb(50, 222, 222, 222);

            // 将三个发射器添加到粒子对象中
            geoParticle.AddEmitter(emitter);

            geoParticle.Play();
            GSOFeature feature = new GSOFeature();
            feature.Geometry = geoParticle;
            globeControl1.Globe.FlyToFeature(feature);

            return feature;
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + "/LSPipeline用户使用手册.chm");
        }

        private void 管线高级查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQueryPipelineBySQL sqlQuery = new FrmQueryPipelineBySQL(globeControl1);
            sqlQuery.Show(this);           
        }

        private void 显示漏出地面管线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayers layers = globeControl1.Globe.Layers;
            if (layers.Count <= 0)
            {
                MessageBox.Show("请先添加图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmOutEarth frm = new FrmOutEarth(globeControl1);
            frm.Show(this);
        }
        public static string filename = Application.StartupPath + "\\FormText.xml";
        private static bool LoadConfig()
        {
            if (File.Exists(filename))
            {
                XmlTextReader XmlReader = new XmlTextReader(filename);
                try
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.Name == "queryfield")
                        {
                            Utility.Query_Fields.Add(XmlReader["label"], XmlReader.ReadElementString());
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    XmlReader.Close();
                }
            }
            else
            {
                MessageBox.Show("配置文件不存在！", "提示");
                return false;
            }
        }

        private void 管线碰撞分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnalysisCollision collisionAnalysis = new FrmAnalysisCollision(globeControl1);
            collisionAnalysis.Show(this);
        }
        //创建拓扑
        private void generateTopoDataMenuItem_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmCreateGenTopo frm = new FrmCreateGenTopo(globeControl1);
            frm.Show(this);
        }

        //连通性分析 
        private Point m_pntRMouseDown;
        private GSOFeature m_ConnexityAnalysisFirstFeature;
        private GSOFeature m_ConnexityAnaylsisSecondFeature;
        private GSOLayer m_ConnexityAnalysisFirstLayer;
        private GSOLayer m_COnnexityAnalysisSecondLayer;
        private GSOFeatures m_ConnexityAnalyResFeatures;
        private GSOFeatures m_TraceUpDownAnalyResFeatures;
        private GSOFeatures m_CloseValvesAnalyResFeatures;

        ArrayList m_CloseValvesList = new ArrayList();//声明集合存储阀门分析的阀门Feature对象

        private void ConnexityAnalysisMenuItem_Click(object sender, EventArgs e)//连通性分析
        {
            if (globeControl1.Globe.SelObjectCount < 2)
            {
                MessageBox.Show("请选中至少两个管线！！");
                return;
            }
            ClearConnexityAnalysis();
            globeControl1.Globe.GetSelectObject(0, out m_ConnexityAnalysisFirstFeature, out m_ConnexityAnalysisFirstLayer);
            globeControl1.Globe.GetSelectObject(1, out m_ConnexityAnaylsisSecondFeature, out m_COnnexityAnalysisSecondLayer);
            GSOGeoPolyline3D line1 = m_ConnexityAnalysisFirstFeature.Geometry as GSOGeoPolyline3D;
            GSOGeoPolyline3D line2 = m_ConnexityAnaylsisSecondFeature.Geometry as GSOGeoPolyline3D;
            if (line1 == null || line2 == null)
            {
                MessageBox.Show("请选择管线！！");
                return;
            }
            GSOPipeLineStyle3D pipeStyle1 = line1.Style as GSOPipeLineStyle3D;
            GSOPipeLineStyle3D pipeStyle2 = line2.Style as GSOPipeLineStyle3D;
            if (pipeStyle1 == null || pipeStyle2 == null)
            {
                MessageBox.Show("请选择管线！！");
                return;
            }
            if (!m_COnnexityAnalysisSecondLayer.IsSameInnerObject(m_COnnexityAnalysisSecondLayer))
            {
                MessageBox.Show("不在同一个图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearConnexityAnalysis();
            }
            else
            {
                ConnexityAnalysis();
            }
        }
        private void ConnexityAnalysis()
        {
            GSODataset curCAYDataset = m_ConnexityAnalysisFirstLayer.Dataset;
            string srName = curCAYDataset.Name;
            GSONetworkDataset curCAYNDataset = curCAYDataset.DataSource.GetDatasetByName(srName + "Network") as GSONetworkDataset;
            if (curCAYNDataset == null)
            {
                MessageBox.Show("该图层没有创建网络拓扑，请先创建网络拓扑信息再进行分析！", "提示");
                return;
            }

            int[] arryResID;
            curCAYNDataset.ConnexityAnalysis(m_ConnexityAnalysisFirstFeature.ID, m_ConnexityAnaylsisSecondFeature.ID, out arryResID, false, true);
            m_ConnexityAnalyResFeatures = m_ConnexityAnalysisFirstLayer.GetFeaturesByIDs(arryResID);
            if (m_ConnexityAnalyResFeatures == null || m_ConnexityAnalyResFeatures.Length < 1)
            {
                String strLine1 = "管线：" + m_ConnexityAnalysisFirstFeature.ID;
                String strLine2 = "管线：" + m_ConnexityAnaylsisSecondFeature.ID;
                MessageBox.Show(strLine1 + " 与 " + strLine2 + " 不连通", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                int nCount = m_ConnexityAnalyResFeatures.Length;
                GSOGeoPolyline3D effectLine = new GSOGeoPolyline3D();
                GSOPoint3ds effectPart = new GSOPoint3ds();
                for (int i = 0; i < nCount; i++)
                {
                    m_ConnexityAnalyResFeatures[i].HighLight = true;
                    GSOGeoPolyline3D geoline = m_ConnexityAnalyResFeatures[i].Geometry as GSOGeoPolyline3D;
                    if (geoline != null)
                    {
                        //管线显示流动效果
                        for (int j = 0; j < geoline.PartCount; j++)
                        {
                            effectLine.AddPart(geoline[j]);
                        }
                    }                    
                }
                effectLine.SmoothToSpline();
                GSOFeature feature = new GSOFeature();
                feature.Geometry = effectLine;
                if (feature.Geometry.Style == null)
                {
                    feature.Geometry.Style = new GSOSimpleLineStyle3D();
                }
                feature.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                ((GSOStyle3D)feature.Geometry.Style).UsingBlur = true;
                globeControl1.Globe.MemoryLayer.AddFeature(feature);

                GSOAniFeature featureAnimation = new GSOAniFeature();//动画的类型--要素动画
                featureAnimation.Feature = feature;                  //动画的关联对象 

                GSOGeoMarker marker = new GSOGeoMarker(0, 0, 0,"");
                GSOMarkerStyle3D markerStyle = new GSOMarkerStyle3D();
                markerStyle.IconPath = Application.StartupPath + "/Resource/image/star4.bmp";
                marker.Style = markerStyle;
                marker.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                GSOFeature markerFeature = new GSOFeature();
                markerFeature.Geometry = marker;

                GSOAniEffectLineGrow effect = new GSOAniEffectLineGrow();//动画效果-线增长动画
                effect.StartValue = 0;
                effect.EndValue = 1;
                effect.FrameCount = 1200;
                effect.RepeatCount = 1;
                effect.IsSmooth = false;
                effect.ActorFeature = markerFeature;

                GSOAniKeyFrame keyFream = new GSOAniKeyFrame(); //关键帧
                keyFream.Frame = 0;
                keyFream.AddEffect(effect);                     //给关键帧添加动画效果

                GSOAniObjTimeLine timeLine = new GSOAniObjTimeLine();//动画对象
                timeLine.Name = "线增长动画对象";
                timeLine.AniObject = featureAnimation;               //动画对象的动画类型
                timeLine.AddKeyFrame(keyFream);                      //给动画对象添加关键帧

                GSOAnimationPage page = new GSOAnimationPage();      //动画
                page.FPS = 60;                                       //动画--帧率
                page.FrameCount = 20 * 60; //动画时长 * 帧率         //动画--帧总数
                page.Name = "线增长动画";
                page.AddObjTimeLine(timeLine);                       //给动画添加动画对象

                globeControl1.Globe.AnimationPages.Add(page);

                globeControl1.Globe.AnimationPages.GetAt(globeControl1.Globe.AnimationPages.Length - 1).Play();

                globeControl1.Refresh();
            }
        }
        private void ClearConnexityAnalysis()//清除连通性分析结果
        {
            if (m_ConnexityAnalysisFirstFeature != null)
            {
                m_ConnexityAnalysisFirstFeature.HighLight = false;
                m_ConnexityAnalysisFirstFeature.Label = null;
            }
            if (m_ConnexityAnaylsisSecondFeature != null)
            {
                m_ConnexityAnaylsisSecondFeature.HighLight = false;
                m_ConnexityAnaylsisSecondFeature.Label = null;
            }

            m_ConnexityAnalysisFirstFeature = null;
            m_ConnexityAnaylsisSecondFeature = null;
            m_ConnexityAnalysisFirstLayer = null;
            m_COnnexityAnalysisSecondLayer = null;

            if (m_ConnexityAnalyResFeatures != null)
            {
                int nCount = m_ConnexityAnalyResFeatures.Length;

                for (int i = 0; i < nCount; i++)
                {
                    m_ConnexityAnalyResFeatures[i].HighLight = false;
                    GSOGeoPolyline3D geoline = m_ConnexityAnalyResFeatures[i].Geometry as GSOGeoPolyline3D;
                    if (geoline != null)
                    {
                        GSOLineStyle3D lineStyle = geoline.Style as GSOLineStyle3D;
                        if (lineStyle != null)
                        {
                            lineStyle.ArrowVisible = false;
                        }
                    }
                }
                m_ConnexityAnalyResFeatures = null;
            }
        }

        private void CloseValvesAnalysisMenuItem_Click(object sender, EventArgs e)//关阀分析
        {
            ClearCloseValvesAnalysisMenuItem_Click(sender,e);
            if (globeControl1.Globe.SelObjectCount < 1)
            {
                MessageBox.Show("请选中至少一个管线！！");
                return;
            }
            GSOLayer resLayer = null;
            GSOFeature resFeature = null;
            globeControl1.Globe.GetSelectObject(0, out resFeature, out resLayer);
            GSOGeoPolyline3D line1 = resFeature.Geometry as GSOGeoPolyline3D;
            if (line1 == null)
            {
                MessageBox.Show("请选择管线！！");
                return;
            }
            GSOPipeLineStyle3D pipeStyle1 = line1.Style as GSOPipeLineStyle3D;
            if (pipeStyle1 == null)
            {
                MessageBox.Show("请选择管线！！");
                return;
            }
            GSOPoint3d resIntersetPoint = new GSOPoint3d();
            if (NetworkCloseValvesAnalysis(resFeature, resIntersetPoint, resLayer))
            {
                //btnGFFX.Checked = false;
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
            }
        }
        private bool NetworkCloseValvesAnalysis(GSOFeature lineFeature, GSOPoint3d pntBreak, GSOLayer lineLayer)//阀门分析
        {
            if (lineLayer == null || lineFeature == null || lineFeature.Geometry == null || lineFeature.Geometry.Type != EnumGeometryType.GeoPolyline3D)
            {
                return false;
            }
            GSODataset curCAYDataset = lineLayer.Dataset;

            if (curCAYDataset == null || curCAYDataset.DataSource == null)
            {
                return false;
            }
            string srName = curCAYDataset.Name;
            GSONetworkDataset curCAYNDataset = curCAYDataset.DataSource.GetDatasetByName(srName + "Network") as GSONetworkDataset;

            if (curCAYNDataset == null)
            {
                MessageBox.Show("该图层没有创建网络拓扑，请先创建网络拓扑信息再进行分析！", "提示");
                return false;
            }
            ClearCloseValvesAnalysisMenuItem_Click(null, null);

            int[] arryResNodeID;
            int[] arryResValveID;
            curCAYNDataset.CloseValveAnalysis(lineFeature.ID, out arryResNodeID, out arryResValveID, false, true);
            if (arryResValveID != null)
            {
                if (lineFeature.GetFieldAsInt32("管线编码") >= 6000 && lineFeature.GetFieldAsInt32("管线编码") <= 6203)  // 6100是热力管线的编码
                {
                    GSOLayer ValveLayer = globeControl1.Globe.Layers.GetLayerByCaption("热力阀门");
                    if (ValveLayer != null)
                    {
                        m_CloseValvesAnalyResFeatures = ValveLayer.GetFeaturesByIDs(arryResValveID);
                    }
                }
                else if (lineFeature.GetFieldAsInt32("管线编码") >= 5000 && lineFeature.GetFieldAsInt32("管线编码") <= 5200)  // 5000是燃气管线的编码
                {
                    GSOLayer ValveLayer = globeControl1.Globe.Layers.GetLayerByCaption("燃气阀门");
                    if (ValveLayer != null)
                    {
                        m_CloseValvesAnalyResFeatures = ValveLayer.GetFeaturesByIDs(arryResValveID);
                    }
                }
                else if (lineFeature.GetFieldAsInt32("管线编码") >= 3000 && lineFeature.GetFieldAsInt32("管线编码") <= 3513)  // 3000是给水管线的编码
                {
                    GSOLayer ValveLayer = globeControl1.Globe.Layers.GetLayerByCaption("给水阀门");
                    if (ValveLayer != null)
                    {
                        m_CloseValvesAnalyResFeatures = ValveLayer.GetFeaturesByIDs(arryResValveID);
                    }
                }
            }
            if (m_CloseValvesAnalyResFeatures == null ||
                m_CloseValvesAnalyResFeatures.Length < 1)
            {
                MessageBox.Show("没有找到要关闭的阀门!");
            }
            else
            {
                int nCount = m_CloseValvesAnalyResFeatures.Length;
                if (nCount > 0)
                {
                    FrmShowValvesNeedClose frm = FrmShowValvesNeedClose.getForm(globeControl1, m_CloseValvesAnalyResFeatures, m_CloseValvesList);
                    frm.setLstValvesName();
                    if (!frm.Visible)
                    {
                        frm.Show(this);
                    }
                }
            }
            return true;
        }
        private void TraceUpMenuItem_Click(object sender, EventArgs e)//上游追踪
        {
            ClearUpDownTraceMenuItem_Click(sender, e);
            NetworkTraceUpDown(true);
        }        

        private void TraceDownMenuItem_Click(object sender, EventArgs e)//下游追踪
        {
            ClearUpDownTraceMenuItem_Click(sender, e);
            NetworkTraceUpDown(false);
        }

        private void ClearUpDownTraceMenuItem_Click(object sender, EventArgs e)//清除追踪结果
        {
            if (m_TraceUpDownAnalyResFeatures != null)
            {
                int nCount = m_TraceUpDownAnalyResFeatures.Length;
                for (int i = 0; i < nCount; i++)
                {
                    m_TraceUpDownAnalyResFeatures[i].HighLight = false;
                    GSOGeoPolyline3D geoline = m_TraceUpDownAnalyResFeatures[i].Geometry as GSOGeoPolyline3D;
                    if (geoline != null)
                    {
                        GSOLineStyle3D lineStyle = geoline.Style as GSOLineStyle3D;
                        if (lineStyle != null)
                        {
                            lineStyle.ArrowVisible = false;
                        }
                    }
                }
                m_TraceUpDownAnalyResFeatures = null;
            }
        }

        private void ClearCloseValvesAnalysisMenuItem_Click(object sender, EventArgs e)//清除关阀分析结果
        {
            if (m_CloseValvesAnalyResFeatures != null)
            {
                for (int i = 0; i < m_CloseValvesList.Count; i++)
                {
                    GSOFeature feature = m_CloseValvesList[i] as GSOFeature;
                    feature.Label.Text = "";
                }
                globeControl1.Refresh();
                m_CloseValvesAnalyResFeatures = null;
                m_CloseValvesList = new ArrayList();
            }
        }

        private void NetworkTraceUpDown(Boolean bTraceUp)//上下游追踪
        {
            if (globeControl1.Globe.SelectedObject == null)
            {
                MessageBox.Show("请点击“工具”—“选中对象”选择一条线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GSOFeature selLineFeature = globeControl1.Globe.SelectedObject;
            if (selLineFeature.Geometry == null || selLineFeature.Geometry.Type != EnumGeometryType.GeoPolyline3D)
            {
                MessageBox.Show("请点击“工具”—“选中对象”选择一条线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (globeControl1.Globe.SelectedObjectLayer == null)
            {
                return;
            }

            GSODataset curCAYDataset = globeControl1.Globe.SelectedObjectLayer.Dataset;
            if (curCAYDataset == null || curCAYDataset.DataSource == null)
            {
                MessageBox.Show("选中对象所在图层不是数据库图层！", "提示");
                return;
            }

            string srName = curCAYDataset.Name;
            GSONetworkDataset curCAYNDataset = curCAYDataset.DataSource.GetDatasetByName(srName + "Network") as GSONetworkDataset;

            if (curCAYNDataset == null)
            {
                MessageBox.Show("选中对象所在图层没有创建拓扑！","提示");
                return;
            }

            int[] arryResID;
            curCAYNDataset.TraceUpDownAnalysis(selLineFeature.ID, out arryResID, bTraceUp, false, true);
            m_TraceUpDownAnalyResFeatures = globeControl1.Globe.SelectedObjectLayer.GetFeaturesByIDs(arryResID);
            if (m_TraceUpDownAnalyResFeatures == null || m_TraceUpDownAnalyResFeatures.Length < 1)
            {
                String strLine1 = "没有上游！";
                if (!bTraceUp)
                {
                    strLine1 = "没有下游！";

                }
                MessageBox.Show(strLine1);
            }
            else
            {
                int nCount = m_TraceUpDownAnalyResFeatures.Length;

                //显示箭头
                for (int i = 0; i < nCount; i++)
                {
                    m_TraceUpDownAnalyResFeatures[i].HighLight = true;
                    GSOGeoPolyline3D geoline = m_TraceUpDownAnalyResFeatures[i].Geometry as GSOGeoPolyline3D;
                    if (geoline != null)
                    {
                        GSOLineStyle3D lineStyle = geoline.Style as GSOLineStyle3D;
                        if (lineStyle != null)
                        {
                            if (lineStyle.ArrowStyle == null)
                            {
                                lineStyle.ArrowStyle = new GSOArrowStyle();
                                lineStyle.ArrowStyle.BodyWidth = 2;
                                lineStyle.ArrowStyle.BodyLen = 6;
                                lineStyle.ArrowStyle.HeadWidth = 8;
                                lineStyle.ArrowStyle.HeadLen = 10;
                                lineStyle.ArrowStyle.OutlineVisible = true;
                                lineStyle.ArrowStyle.OutlineColor = Color.Red;
                                lineStyle.ArrowStyle.Speed = lineStyle.ArrowStyle.Speed / 2;
                            }
                            lineStyle.ArrowVisible = true;
                            lineStyle.ArrowStyle.Play();
                        }
                    }
                }

                //动画
                //GSOLayer layer = globeControl1.Globe.Layers.Add(Application.StartupPath + "/MyPlace.kml");
                //if (layer != null)
                //{
                //    GSOAnimationPage page = new GSOAnimationPage();      //动画
                //    page.FPS = 60;                                       //动画--帧率
                //    page.FrameCount = 20 * 60; //动画时长 * 帧率         //动画--帧总数
                //    page.Name = "线增长动画";
                //    GSOAniObjTimeLine timeLine = new GSOAniObjTimeLine();//动画对象
                //    timeLine.Name = "线增长动画对象";                                     

                //    for (int i = 0; i < nCount; i++)
                //    {
                //        m_TraceUpDownAnalyResFeatures[i].HighLight = false;
                //        GSOGeoPolyline3D geoline = m_TraceUpDownAnalyResFeatures[i].Geometry as GSOGeoPolyline3D;
                //        if (geoline != null && geoline.PartCount > 0)
                //        {
                //            GSOPoint3d endPoint = geoline[0][0];
                //            if (endPoint != null)
                //            {
                //                GSOFeatures featuresInPolygon = getFeatureByPolygon(layer, m_TraceUpDownAnalyResFeatures, endPoint, 0.1);
                //                if (featuresInPolygon != null && featuresInPolygon.Length == 0)
                //                {
                //                    timeLine = createKeyFrame(timeLine, m_TraceUpDownAnalyResFeatures[i]);
                //                    endPoint = geoline[geoline.PartCount - 1][geoline[geoline.PartCount - 1].Count - 1];
                //                }
                //            }
                //        }
                //    }
                                  
                //    page.AddObjTimeLine(timeLine);
                //    globeControl1.Globe.AnimationPages.Add(page);
                //    globeControl1.Globe.AnimationPages.GetAt(globeControl1.Globe.AnimationPages.Length - 1).Play();
                //    globeControl1.Refresh();
                //}
                //else 
                //{
                //    MessageBox.Show("没有动画演示需要的临时图层MyPlace","提示");
                //}

                globeControl1.Refresh();
            }
        }
        private GSOFeatures getFeatureByPolygon(GSOLayer layer,GSOFeatures features, GSOPoint3d point, double allowValue)
        {
            if (layer == null || point == null || allowValue <= 0)
            {
                return null;
            }
            GSOGeoPolyline3D bufferLine = new GSOGeoPolyline3D();
            GSOPoint3ds points = new GSOPoint3ds();
            points.Add(point);
            GSOPoint3d newPoint = new GSOPoint3d();
            newPoint.X = point.X + 0.00001;
            newPoint.Y = point.Y;
            newPoint.Z = point.Z;
            points.Add(newPoint);
            bufferLine.AddPart(points);
            GSOGeoPolygon3D polygon = bufferLine.CreateBuffer(allowValue, true, 12, false, false);
            layer.RemoveAllFeature();
            layer.AddFeatures(features);
            GSOFeatures featuresInPolygon = layer.FindFeaturesInPolygon(polygon, false);
            return featuresInPolygon;
        }
        private GSOAniObjTimeLine createKeyFrame(GSOAniObjTimeLine timeLine, GSOFeature featureAboutAnimation)
        {
            if (timeLine == null || featureAboutAnimation == null || featureAboutAnimation.Geometry == null)
            {
                return null;
            }
            GSOFeature feature = featureAboutAnimation.Clone();
            if (feature.Geometry.Style == null || feature.Geometry.Style is GSOSimpleLineStyle3D)
            {
                feature.Geometry.Style = new GSOPipeLineStyle3D();
            }
            feature.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
            ((GSOGeoPolyline3D)feature.Geometry).SmoothToSpline();
            ((GSOStyle3D)feature.Geometry.Style).UsingBlur = true;
            globeControl1.Globe.MemoryLayer.AddFeature(feature);

            GSOAniFeature featureAnimation = new GSOAniFeature();//动画的类型--要素动画
            featureAnimation.Feature = feature;                  //动画的关联对象                   

            GSOAniEffectLineGrow effect = new GSOAniEffectLineGrow();//动画效果-线增长动画
            effect.StartValue = 0;
            effect.EndValue = 1;
            effect.FrameCount = 1200;
            effect.RepeatCount = 1;
            //effect.IsSmooth = false;

            GSOAniKeyFrame keyFream = new GSOAniKeyFrame(); //关键帧
            keyFream.Frame = 0;
            keyFream.AddEffect(effect);                     //给关键帧添加动画效果

            timeLine.AddKeyFrame(keyFream);
            return timeLine;
        }

        private void 更改要素的名字toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmUpdateFeatureNames updateNames = new FrmUpdateFeatureNames(globeControl1);
            updateNames.Show(this);
        }
        string trackPolygonEndFunction = "";
        private void 框选删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string caption = "我的地标";
            GSOLayer layer = globeControl1.Globe.DestLayerFeatureAdd;
            if(layer != null)
            {
                caption = layer.Caption;
            }
            DialogResult result = MessageBox.Show("框选删除针对当前目标图层：" + caption, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
                ActionToolMenuChecked();
                trackPolygonEndFunction = "polygonDelete"; 
            }                       
        }

        private void 横断面分析toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (!横断面分析toolStripMenuItem3.Checked)
            {
                globeControl1.Globe.Action = EnumAction3D.TrackPolyline;
                globeControl1.Globe.TrackPolylineTool.VerticalLineVisible = true;
                横断面分析toolStripMenuItem3.Checked = true;
            }
            else
            {
                globeControl1.Globe.Action = EnumAction3D.ActionNull;
                globeControl1.Globe.TrackPolylineTool.VerticalLineVisible = false;
                横断面分析toolStripMenuItem3.Checked = false;
            }
            ActionToolMenuChecked();
        }

        private void 管线间距分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelObjectCount < 2)
            {
                MessageBox.Show("请选中至少两个管线！！");
                return;
            }
            if (disFeature.ID != 0)
            {
                globeControl1.Globe.MemoryLayer.RemoveFeatureByID(disFeature.ID);
            }
            if (featureDis.ID != 0)
            {
                globeControl1.Globe.MemoryLayer.RemoveFeatureByID(featureDis.ID);
            }
            GSOLayer reslayer;
            globeControl1.Globe.GetSelectObject(0, out m_DisAnalysisFirstFeature, out reslayer);
            globeControl1.Globe.GetSelectObject(1, out m_DisAnalysisSecondFeature, out reslayer);
            if (m_DisAnalysisSecondFeature != null && m_DisAnalysisSecondFeature != null)
            {
                GSOGeoPolyline3D line1 = m_DisAnalysisFirstFeature.Geometry as GSOGeoPolyline3D;
                GSOGeoPolyline3D line2 = m_DisAnalysisSecondFeature.Geometry as GSOGeoPolyline3D;
                if (line1 == null || line2 == null)
                {
                    MessageBox.Show("请选择管线！！");
                    return;
                }
                GSOPipeLineStyle3D pipeStyle1 = line1.Style as GSOPipeLineStyle3D;
                GSOPipeLineStyle3D pipeStyle2 = line2.Style as GSOPipeLineStyle3D;
                if (pipeStyle1 == null || pipeStyle2 == null)
                {
                    MessageBox.Show("请选择管线！！");
                    return;
                }

                GSOPoint3d pntIntersect1;
                GSOPoint3d pntIntersect2;
                double dHonLen;
                double dVerLen;
                double dNoIntersectStartRatio = 0;
                // 计算两条线的距离和交点，若果失败返回-1
                // 若在同一直线上，并且有交点，返回0
                // 若不在同一平面，返回最近两点的距离，并且计算最近两点
                double dDist = globeControl1.Globe.Analysis3D.ComputeTwoGeoPolylineDistance(line1, line2, out pntIntersect1, out pntIntersect2, out dHonLen, out dVerLen, false, false, dNoIntersectStartRatio);

                if (dDist > -1)
                {
                    if (dDist == 0)
                    {
                        MessageBox.Show("管线在同一水平面，距离为0");
                        return;
                    }
                    else
                    {
                        dDist = dDist - pipeStyle1.Radius - pipeStyle2.Radius;
                        GSOGeoPolyline3D disline = new GSOGeoPolyline3D();
                        GSOPoint3ds point3ds = new GSOPoint3ds();
                        point3ds.Add(pntIntersect1);
                        point3ds.Add(pntIntersect2);
                        disline.AddPart(point3ds);

                        GSOSimpleLineStyle3D style = new GSOSimpleLineStyle3D(); //创建线的风格
                        //设置透明度及颜色，FromArgb()中的四个参数分别为alpha、red、green、blue，取值范围为0到255
                        style.LineColor = Color.GreenYellow;
                        style.LineWidth = 3;          //设置线的宽度为3
                        style.VertexVisible = true; 	//显示线的节点
                        disline.Style = style;          //把风格添加到线上
                        disline.AltitudeMode = EnumAltitudeMode.Absolute;

                        disFeature.Geometry = disline;

                        GSOGeoMarker markerDis = new GSOGeoMarker();
                        markerDis.X = pntIntersect1.X;
                        markerDis.Y = pntIntersect1.Y;
                        markerDis.Z = (pntIntersect1.Z + pntIntersect2.Z) / 2;
                        markerDis.Text = dDist.ToString().Substring(0, dDist.ToString().IndexOf(".") + 3) + "米";
                        markerDis.AltitudeMode = EnumAltitudeMode.Absolute;
                        GSOMarkerStyle3D styleMarker = new GSOMarkerStyle3D();
                        GSOTextStyle styleText = new GSOTextStyle();
                        styleText.IsSizeFixed = true;
                        styleText.ForeColor = Color.White;
                        styleText.FontSize = 20;
                        styleMarker.TextStyle = styleText;
                        markerDis.Style = styleMarker;
                        featureDis.Geometry = markerDis;
                        layerTemp = globeControl1.Globe.Layers.Add(Application.StartupPath + "\\tempLgdData.lgd");
                        layerTemp.AddFeature(featureDis);
                        layerTemp.AddFeature(disFeature);
                        globeControl1.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("没有交点！！");
                    return;
                }
            }
        }

        private void MainFrm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            SendKeys.Send("{F1}");
        }

        private void 更改图片路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = globeControl1.Globe.Layers.GetLayerByCaption("china");
            GSOFeatures fe = layer.GetAllFeatures();
            for (int i = 0; i < fe.Length; i++)
            {
                GSOFeature f = fe[i];
                GSOGeoPoint3D p = f.Geometry as GSOGeoPoint3D;
                GSOPointStyle3D style = p.Style as GSOPointStyle3D;                
            }
        }

        private void SetSelLevelMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetSelectLevel dlg = new FrmSetSelectLevel();
            dlg.m_strTerrainExtra = globeControl1.Globe.SelLevel.ToString();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.m_strTerrainExtra.Trim() != "")
                {
                    int selselvel = 0;
                    bool bl = int.TryParse(dlg.m_strTerrainExtra.Trim(), out selselvel);
                    if (bl)
                    {
                        globeControl1.Globe.SelLevel = selselvel;
                        globeControl1.Globe.Refresh();
                        ActionToolMenuChecked();
                    }
                }
            }
        }

        private void 清除连通分析结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearConnexityAnalysis();
        }        

        private void 备份数据库toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (isGlobeContainsDataSource() == false)
            {
                FrmMessageBox frmMessage = new FrmMessageBox();
                DialogResult result = frmMessage.ShowDialog();
                if (result == DialogResult.OK)
                {
                    连接数据库ToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    连接Oracle数据库toolStripMenuItem6_Click(sender, e);
                }
                else
                {
                    return;
                }
            }
            if (isGlobeContainsDataSource() == false)
            {
                return;
            }
            FrmBackupDatabase frm = new FrmBackupDatabase(globeControl1);
            frm.Show(this);
        }        

        private void 面转为水面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = layerNodeContexMenu.Tag as TreeNode;

            GSOLayer layer = node.Tag as GSOLayer;
            GSOFeatures features = layer.GetAllFeatures();
            if (features.Length <= 0)
            {
                MessageBox.Show("图层中没有对象");
                return;
            }

            FrmPolygonToWater polygonToWater = new FrmPolygonToWater(globeControl1,layer);
            if (polygonToWater.ShowDialog(this) == DialogResult.OK)
            {
                RefreshTreeNodeLayerFeatureList(node);
            }
        }

        private void toolStripMenuItem条件删除管线_Click(object sender, EventArgs e)
        {
            FrmDeleteLines frmDeleteLines = new FrmDeleteLines(globeControl1);
            frmDeleteLines.Show(this);
        }

        private void 数据验证toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmValiData frm = new FrmValiData(globeControl1);
            frm.Show(this);
        }

        private void 求解假东假北ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFalseEastNorth frm = new FrmFalseEastNorth();
            frm.Show(this);
        }

        private void 线增长动画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelectedObject != null)
            {
                GSOFeature feature = globeControl1.Globe.SelectedObject;
                feature.HighLight = false;
                globeControl1.Globe.Refresh();
                if (feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                {
                    if (feature.Geometry.Style == null)
                    {
                        feature.Geometry.Style = new GSOSimpleLineStyle3D();
                    }
                    feature.Geometry.AltitudeMode = EnumAltitudeMode.RelativeToGround;
                    ((GSOGeoPolyline3D)feature.Geometry).SmoothToSpline();
                    ((GSOStyle3D)feature.Geometry.Style).UsingBlur = true;
                    globeControl1.Globe.MemoryLayer.AddFeature(feature);

                    GSOAniFeature featureAnimation = new GSOAniFeature();//动画的类型--要素动画
                    featureAnimation.Feature = feature;                  //动画的关联对象                    

                    GSOAniEffectLineGrow effect = new GSOAniEffectLineGrow();//动画效果-线增长动画
                    effect.StartValue = 0;
                    effect.EndValue = 1;
                    effect.FrameCount = 1200;
                    effect.RepeatCount = 1;
                    //effect.IsSmooth = false;

                    GSOAniKeyFrame keyFream = new GSOAniKeyFrame(); //关键帧
                    keyFream.Frame = 0;
                    keyFream.AddEffect(effect);                     //给关键帧添加动画效果

                    GSOAniObjTimeLine timeLine = new GSOAniObjTimeLine();//动画对象
                    timeLine.Name = "线增长动画对象";
                    timeLine.AniObject = featureAnimation;               //动画对象的动画类型
                    timeLine.AddKeyFrame(keyFream);                      //给动画对象添加关键帧

                    GSOAnimationPage page = new GSOAnimationPage();      //动画
                    page.FPS = 60;                                       //动画--帧率
                    page.FrameCount = 20 * 60; //动画时长 * 帧率         //动画--帧总数
                    page.Name = "线增长动画";
                    page.AddObjTimeLine(timeLine);                       //给动画添加动画对象

                    globeControl1.Globe.AnimationPages.Add(page);
                    globeControl1.Globe.AnimationPages.GetAt(globeControl1.Globe.AnimationPages.Length - 1).Play();
                    globeControl1.Refresh();
                }
                else
                {
                    MessageBox.Show("请选中一条线！","提示");
                }
            }
        }

        private void 管线自动缩进toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            FrmPipelineIndented frm = new FrmPipelineIndented(globeControl1);
            frm.Show(this);
        }

        private void 选中发光ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globeControl1.Globe.SelObjectCount < 1)
            {
                MessageBox.Show("请选中要发光的对象！","提示");
                return;
            }
           
            for (int i = 0; i < globeControl1.Globe.SelObjectCount; i++)
            {
                GSOFeature feature = null;
                GSOLayer layer = null;
                globeControl1.Globe.GetSelectObject(i, out feature, out layer);
                if (feature != null && feature.Geometry != null && feature.Geometry.Style != null)
                {
                    feature.HighLight = false;
                    ((GSOStyle3D)feature.Geometry.Style).UsingBlur = true;
                }
            }
            globeControl1.Globe.Action = EnumAction3D.ActionNull;
            globeControl1.Globe.Action = EnumAction3D.SelectObject;
            globeControl1.Globe.Refresh();
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            int alllength = statusStrip1.Width;
            int leftlength = statusStrip1.Items[0].Width;
            statusStrip1.Items[1].Width = alllength - leftlength - 20;
        }

        private void 更新图层字段值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateLayerFieldValues frm = new FrmUpdateLayerFieldValues(globeControl1);
            frm.Show(this);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FrmBatchExportLayerByZ frm = new FrmBatchExportLayerByZ(globeControl1);
            frm.Show(this);
        }

        private void 检查图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = globeControl1.Globe.DestLayerFeatureAdd;
            if (layer != null && layer.ID == globeControl1.Globe.MemoryLayer.ID)
            {
                MessageBox.Show("请先设置目标图层！","提示");
                return;
            }
            if (layer.Dataset != null && layer.Dataset.IsFeatureDataset == true)
            {
                GSOFeatureDataset dataset = layer.Dataset as GSOFeatureDataset;
                for (int i = 0; i < dataset.GetAllFeatures().Length; i++)
                {
                    GSOFeature feature = dataset.GetFeatureAt(i);
                    if (feature != null && feature.GetFieldCount() < dataset.FieldCount)
                    {
                        for (int j = 0; j < dataset.FieldCount; j++)
                        {
                            GSOFieldAttr field = dataset.GetField(j);
                            if (field != null && feature.GetFieldDefn(field.Name) == null)
                            {
                                GSOFieldDefn defn = new GSOFieldDefn();
                                defn.Name = field.Name;
                                defn.Type = field.Type;
                                defn.Width = field.Width;
                                feature.AddField(defn);
                            }
                        }
                    }
                }
                MessageBox.Show("检查完毕！","提示");
            }
        }
        //框选部分feature对象进行属性字段编辑
        private void 框选打开属性表toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            globeControl1.Globe.Action = EnumAction3D.TrackPolygon;
            trackPolygonEndFunction = "polygonOpenAttributes";
        }
        //去除管线对象中多余的节点
        private void 检查管线节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GSOLayer layer = globeControl1.Globe.DestLayerFeatureAdd;
            if (layer != null && layer.ID == globeControl1.Globe.MemoryLayer.ID)
            {
                MessageBox.Show("请先设置目标图层！", "提示");
                return;
            }
            FrmCheckPipelinePoint frm = new FrmCheckPipelinePoint();
            if (frm.ShowDialog() == DialogResult.OK && layer.GetAllFeatures().Length > 0)
            {
                double distance = frm.pointDistance;
                for (int i = 0; i < layer.GetAllFeatures().Length; i++)
                {
                    GSOFeature feature = layer.GetAt(i);
                    if (feature != null && feature.Geometry != null && feature.Geometry.Type == EnumGeometryType.GeoPolyline3D)
                    {
                        GSOGeoPolyline3D line = feature.Geometry as GSOGeoPolyline3D;  
                        //获取管线中所有节点
                        GSOPoint3ds allPoint = new GSOPoint3ds();
                        for (int j = 0; j < line.PartCount; j++)
                        {
                            GSOPoint3ds points = line[j];
                            if (points != null)
                            {
                                for (int m = 0; m < points.Count; m++)
                                {
                                    GSOPoint3d point = points[m];
                                    allPoint.Add(point);
                                }
                            }
                        }
                        if (allPoint.Count > 2)
                        {
                            for (int j = 0; j < allPoint.Count - 1; j++)
                            {
                                GSOPoint3d point = allPoint[j];
                                GSOPoint3d point1 = allPoint[j + 1];
                                GSOPoint3ds points = new GSOPoint3ds();
                                points.Add(point);
                                points.Add(point1);
                                GSOGeoPolyline3D newLine = new GSOGeoPolyline3D();
                                newLine.AddPart(points);
                                double length = newLine.GetSpaceLength(false, 6378137.0);
                                if (length < distance)
                                {
                                    if (j == allPoint.Count - 2)
                                    {
                                        allPoint.Remove(j);
                                    }
                                    else
                                    {
                                        allPoint.Remove(j + 1);
                                    }
                                    if (allPoint.Count < 3)
                                    {
                                        break;
                                    }
                                    j--;
                                }
                            }
                        }
                        line.Clear();
                        line.AddPart(allPoint);
                        feature.Geometry = line;
                        globeControl1.Refresh();
                    }
                }                
            }
            MessageBox.Show("检查完毕！", "提示");
        }

        private void 连接Oracle数据库toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FrmDatabaseParaSettingOracle frm = new FrmDatabaseParaSettingOracle(globeControl1);
            frm.ShowDialog();       
        }

       
    }
}
