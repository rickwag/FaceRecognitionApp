   M S B A M L   `   `   `  ����M  IFaceRecognitionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FaceRecognitionApp.ViewsFaceRecognitionApp.Views  5   	   M+clr-namespace:FaceRecognitionApp.ConvertersFaceRecognitionApp.Converters  5   	   0    *FaceRecognitionApp.Views.SelectClassDialog   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:FaceRecognitionApp.Views     5   	   B
converters+clr-namespace:FaceRecognitionApp.Converters     5   	     � Title$  SelectClassDialog��5	   	   $	��390��6#   $	��300��60    � WindowStyle$
 None=�6<    � AllowsTransparency$
 True��6O    � WindowStartupLocation$ CenterOwner=�6i    � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background	 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle
 �� 
TargetType �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetNameJ   DFaceRecognitionApp.Converters.CreateNewLectureBtnVisibilityConverter * &CreateNewLectureBtnVisibilityConverterP   JFaceRecognitionApp.Converters.ConfirmSelectedLectureBtnVisibilityConverter 0 ,ConfirmSelectedLectureBtnVisibilityConverter��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 &	 �    &	     �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $	 	#FFDDDDDD��6;   �� 5   
   $	 	#FF707070��67   �� 5   
   $	 	#FFBEE6FD��6>   �� 5   
   $	 	#FF3C7FB1��6:   �� 5   
   $	 	#FFC4E5F6��6<   �� 5   
   $	 	#FF2C628B��68   �� 5   
   $	 	#FFF4F4F4��6=   �� 5   
   $	 	#FFADB2B5��69   �� 5   
   $	 	#FF838383��6=   �� 5   
   "
 ��6$   .�5      ��  �@�FocusVisualStyle8   61   �� 5        � ��8  6+   �� 5!       � ��8  6,   �� 5"       � ��# � ��6+   �� 5#       � ��$ 1q�60   �� 5$       � ��$ Center=�6;   �� 5%       � ��$ Center=�69   �� 5&       � ��$ 1q�6(   �� 5'       � �� 5(      �� 5)      " ��6&   .R�5*      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   $ 20��6�   ._�5+      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5,       5-      P� 5.       �@��IsDefaulted$
 true��6=   . �5/   "   �� $ border��6@   # � ��6T    � ��50      P� 51       �@J�IsMouseOver$
 true��6=   . �52   "   �� $ border��6?   8   � ��6S   �� 53   "   $ border��6@   8   � ��6T   54      P� 55       � ��$
 true��6;   . �56   "   �� $ border��6?   8   � ��6S   �� 57   "   $ border��6@   8   � ��6T   58      P� 59       � {�$ false��6;   . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   �� 5<   "   $ contentPresenter��6K   8 	  � ��6i   5=      5?      5A      5B        5D   
   6<     5E   
   6B   5F      .��5H      �   greenishColor#��[ 6    � RowDefinitions 5I   
   �� 5J      $	��.3* �6   �� 5K      $��* �6   �� 5L      $	��.3* �6   .+�5P   
   �� $��select a class��6   $��28(�5Q        purpleishColor#��[ 5R      $��Center=�5S      $��Center=�5T      �� 5V   
   $��1��6   
������ $��Stretch=�5Y        bluishColor#��[ 5Z      ��5X      �� *	Classes+ �� SelectedItem 5[      �� *SelectedLecture+��5]      �� 5^      .R�5_      �� $��2q�6   #��[ 5`      ._�5a      �� #��[ 5b   $   $��Center=�5c   $    �� Padding$ 5q�5d   $   ��5a   $   �� *Name+5d   $   5e      5f      5i      �� 5k   
   #��� 
 6   $��create new class��5l      $	��260��5m      $��40��5n      #��[ 5o      
������ #��[ 5q      $��3q�5r      $��18(�5s      $��2��5t      ��5u      �� *ShowNewClassDialogCommand+y�5v      �� *SelectedLecture+ �� 	Converter# [ �� 5x   
   #��� 
 6   $��confirm selection��5y      $	��260��5z      $��40��5{      #��[ 5|      
������ #��[ 5~      $��3q�5      $��18(�5�      $��2��5�      ��5�      �� *ConfirmSelectedClassCommand+y�5�      �� *SelectedLecture+# [ 5�      5�      