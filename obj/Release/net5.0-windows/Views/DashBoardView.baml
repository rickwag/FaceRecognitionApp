   M S B A M L   `   `   `  ���� M  IFaceRecognitionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FaceRecognitionApp.ViewsFaceRecognitionApp.Views  ,    &FaceRecognitionApp.Views.DashBoardView   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8local&clr-namespace:FaceRecognitionApp.Views       � 	Resources     FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 CardButtonStyle �� 
TargetType �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName  purpleishColor  buttonHeaderTextStyle  greenishColor  buttonDetailTextStyle  bluishColor��%%  &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 &	 	    7  &	 >    7  �� .���  � �� �� .R��� $��2q�$	 1 2R�$
 true��$��1��#��� ���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ Black���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 true��$	 20��._��� $
 contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ���� " ��.���  � ��8   ��  � ��$ 22(��� " ��.���  � ��8   ��  � ��$ 15(�.��� #��[ .+���   backgroundSvg#��[ �� $	��250��$	��160��$	 10��$
��Left=�$	��Top=�����  �� ImageSource$ /Eye.png���� #��[  J� Opacity$ .8Q�$	��250��$	��160��$
��Left=�$	��Top=� �� RadiusX$ 10�� �� RadiusY$ 10���� $��/EyeLock.png��$	��200��$��25 45q�$
��Left=�$	��Top=��� ���	#334FFBDF$��Center=�$��Bottom=�$	 20��._�� $	��400��$	��220��$��Center=�$��Bottom=�.+��� #��� 
 $	��180��$	��180��$��0q�$��Center=�$��Center=�$
��Left=�$	��Top=����� *NavigateToRegisterNewStudent+���� $ /darkStudent.png������  �� Orientation$ Vertical=�$��10q�.+��� $��registration��#��[ �� $"��add a new student to a class��$
��Wrap=�#��[ �� #��� 
 $	��180��$	��180��$��0q�$��Center=�$��Center=�$��Right=�$	��Top=����� *NavigateToMarkAttendance+���� $ /lookFor.png������ $ Vertical=�$��10q�.+��� $��
attendance��#��[ �� $��record student attendance��$
��Wrap=�#��[ 