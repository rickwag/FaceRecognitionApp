   M S B A M L   `   `   `  ���� M  IFaceRecognitionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FaceRecognitionApp.ViewsFaceRecognitionApp.Views  M+clr-namespace:FaceRecognitionApp.ConvertersFaceRecognitionApp.Converters  0    *FaceRecognitionApp.Views.SelectClassDialog   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:FaceRecognitionApp.Views     B
converters+clr-namespace:FaceRecognitionApp.Converters       � Title$  SelectClassDialog��$	��390��$	��300�� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � WindowStartupLocation$ CenterOwner=� � 	Resources    FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background	 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle
 �� 
TargetType �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetNameJ   DFaceRecognitionApp.Converters.CreateNewLectureBtnVisibilityConverter * &CreateNewLectureBtnVisibilityConverterP   JFaceRecognitionApp.Converters.ConfirmSelectedLectureBtnVisibilityConverter 0 ,ConfirmSelectedLectureBtnVisibilityConverter��%�  &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 &	     &	     �� .���  � �� �� .R��� $��2q�$	 1 2R�$
 true��$��1��#��� ���� $	 	#FFDDDDDD���� $	 	#FF707070���� $	 	#FFBEE6FD���� $	 	#FF3C7FB1���� $	 	#FFC4E5F6���� $	 	#FF2C628B���� $	 	#FFF4F4F4���� $	 	#FFADB2B5���� $	 	#FF838383���� "
 ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 true��$ 20��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ��    .���   greenishColor#��[  � RowDefinitions �� $	��.3* ��� $��* ��� $	��.3* �.+��� $��select a class��$��28(�  purpleishColor#��[ $��Center=�$��Center=��� $��1��
������ $��Stretch=�  bluishColor#��[ ���� *	Classes+ �� SelectedItem �� *SelectedLecture+���� .R��� $��2q�#��[ ._��� #��[ $��Center=� �� Padding$ 5q����� *Name+�� #��� 
 $��create new class��$	��260��$��40��#��[ 
������ #��[ $��3q�$��18(�$��2������ *ShowNewClassDialogCommand+y��� *SelectedLecture+ �� 	Converter# [ �� #��� 
 $��confirm selection��$	��260��$��40��#��[ 
������ #��[ $��3q�$��18(�$��2������ *ConfirmSelectedClassCommand+y��� *SelectedLecture+# [ 