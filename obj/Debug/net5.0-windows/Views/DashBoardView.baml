   M S B A M L   `   `   `  ����M  IFaceRecognitionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FaceRecognitionApp.ViewsFaceRecognitionApp.Views  5      ,    &FaceRecognitionApp.Views.DashBoardView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:FaceRecognitionApp.Views     5        � 	Resources  5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 CardButtonStyle �� 
TargetType �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName  purpleishColor  buttonHeaderTextStyle  greenishColor  buttonDetailTextStyle  bluishColor��%�  &	        &	 �     &	 �     &	 �     &	     &	 ;    &	 ^    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 &	 �    7  &	 j    7  �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ Black��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6(   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   $	 20��6�   ._�5)      �� $
 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      �� 5B   
   " ��6.   .�5C      ��  � ��8   5D      �� 5E       � ��$ 22(�5F      5G      �� 5I   
   " ��6.   .�5J      ��  � ��8   5K      �� 5L       � ��$ 15(�5M      5N      5O      .��5Q      � #��[ 6   .+�5R   
   ��   backgroundSvg#��[ 6   �� 5T   
   $	��250��6   $	��160��5U      $	 10��5V      $
��Left=�5W      $	��Top=�5X      ��5Y      �� 5Z       �� ImageSource$ /Eye.png��6   5\      �� 5^   
   #��[ 6    J� Opacity$ .8Q�5_      $	��250��5`      $	��160��5a      $
��Left=�5b      $	��Top=�5c       �� RadiusX$ 10��5d       �� RadiusY$ 10��5e      �� 5g   
   $��/EyeLock.png��6   $	��200��5h      $��25 45q�5i      $
��Left=�5j      $	��Top=�5k      �� 5m   
   ���	#334FFBDF$��Center=�5n      $��Bottom=�5o      $	 20��5p      ._�5q      � $	��400��5r      $	��220��5s      $��Center=�5t      $��Bottom=�5u      .+�5w      �� #��� 
 6   $	��180��5x      $	��180��5y      $��0q�5z      $��Center=�5{      $��Center=�5|      $
��Left=�5}      $	��Top=�5~      ��5      �� *NavigateToRegisterNewStudent+��5�      �� 5�      $ /darkStudent.png��6%   ��5�      �� 5�       �� Orientation$ Vertical=�6%   $��10q�5�   !   .+�5�      �� $��registration��6(   #��[ 5�   $   �� 5�      $"��add a new student to a class��6(   $
��Wrap=�5�   $   #��[ 5�   $   5�      5�      �� 5�      #��� 
 6   $	��180��5�      $	��180��5�      $��0q�5�      $��Center=�5�      $��Center=�5�      $��Right=�5�      $	��Top=�5�      ��5�      �� *NavigateToMarkAttendance+��5�      �� 5�      $ /lookFor.png��6%   ��5�      �� 5�      $ Vertical=�6%   $��10q�5�   !   .+�5�      �� $��
attendance��6(   #��[ 5�   $   �� 5�      $��record student attendance��6(   $
��Wrap=�5�   $   #��[ 5�   $   5�      5�      5�      5�      5�      5�      