   M S B A M L   `   `   `  ����L  HMyImageProcessing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyImageProcessingMyImageProcessing  5          MyImageProcessing.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1localclr-namespace:MyImageProcessing     5        �� 	Resources  5         FlipHorizontalImage  FlipVerticalImage  
RotateLeft  RotateRight  Crop 
 Select  Text 
 Circle  Line 	 	Rectangle 
 Bin  Dropper 	 Paint  Undo  Redo 	 Reset  ToolBarButtonStyle �� 
TargetType �� Property �� Value  ToolBarToggleButtonStyle  LineSeperator  LineSeperatorVertical  
MyExpander �� 
TargetType d�Name d� 	IsChecked �� Mode �� RelativeSource	 ��Name
 � LayoutTransform �� ScaleX �� Triggers P� Property P� Value N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration g� AccelerationRatio N� ExitActions �� 
TargetName �� Padding J� SnapsToDevicePixels � RowDefinitions �� Angle A�Name F�Name �� CenterX �� CenterY �� ContentStringFormat  �� ContentStringFormat  PanelExpander! � FocusVisualStyle" �� StrokeDashArray# �� ScaleY$ � ColumnDefinitions% �� 	Resources��%�!  &	        &	 3     &	 h     &	 �     &	 �     &	 �     &	 #    &	 N    &	 {    &		 �    &	
 �    &	     &	 1    &	 ]    &	 �    &	 �    &	 �    &	 �    &	 !    &	 �    &	 	    &	 ]    �� 5   
   $��./Images/flipvertical.png��6,   �� 5   
   $!��./Images/fliphorizontal.png��6*   �� 5	   
   $��./Images/rotateleft.png��6#   �� 5
   
   $��./Images/rotateright.png��6$   �� 5   
   $��./Images/crop.png��6   �� 5   
   $��./Images/select.png��6   �� 5   
   $��./Images/text.png��6   �� 5   
   $��./Images/circle.png��6   �� 5   
   $��./Images/line.png��6   �� 5   
   $��./Images/rectangle.png��6"   �� 5   
   $��./Images/delete.png��6   �� 5   
   $��./Images/dropper.png��6    �� 5   
   $��./Images/brush.png��6   �� 5   
   $��./Images/undo.png��6   �� 5   
   $��./Images/redo.png��6   �� 5   
   $��./Images/reset.png��6   �� 5   
   " ��6+   .�5      ��  � ��$ 25��6&   63   �� 5       � ��$ 25��6'   64   �� 5       � ��$
 3, 3q�6'   66   5      �� 5   
   " d�61   .�5      ��  � ��$ 25��6&   63   �� 5        � ��$ 25��6'   64   �� 5!       � ��$
 3, 3q�6'   66   5"      �� 5$   
   " ��6&   .�5%      �� 
 �@��X1$ 0��6#   6/   �� 5&      
 �@��X1$ 0��6#   6/   �� 5'      
 �@��X2$ 30��6#   60   �� 5(      
 �@��Y2$ 0��6#   6/   �� 5)       � ��
 �����6;   �� 5*       � ��$ 2��60   6<   �� 5+       � ��$ 5q�6'   63   �� 5,       � ��$ Center=�62   6C   5-      �� 5/   
   " ��6.   .�50      �� 
 �@��X1$ 0��6#   6/   �� 51      
 �@��X1$ 0��6#   6/   �� 52      
 �@��X2$ 0��6#   6/   �� 53      
 �@��Y2$ 30��6#   60   �� 54       � ��
 �����6;   �� 55       � ��$ 2��60   6<   �� 56       � ��$ 5q�6'   63   �� 57       � ��$ Center=�62   6C   58      �� 5:   
   " 9�6#   .�5;      ��  � �� 5<      �� 5=      " 9�6&   .R�5>      ]� 
�������.+�5?      d� $ 
HeaderSite��6A   $
��Left=�6+    6U   �� *
IsExpanded+$ TwoWay=� �� *TemplatedParent+6�   �� 5@      $	 
ExpandSite��6F   $��Right=�6/   
 5A   "   �� 5B   &   $ 0Q�65   6B   5D      5E       5F      P� 5G       �@9�
IsExpanded .  5H   "   �� 5I   &   .��5J   *   �� $ 
ExpandSite��65   $- 'LayoutTransform.(ScaleTransform.ScaleX)�6X   .��5K   .   W� $ 1X�6>   $ 0:0:0.4D�6E   $	 0.5Q�6Y   5L   +   5M   '    5O   "   �� 5P   &   .��5Q   *   �� $ 
ExpandSite��65   $- 'LayoutTransform.(ScaleTransform.ScaleX)�6X   .��5R   .   W� $ 0X�6>   $ 0:0:0.4D�6E   $	 0.5Q�6X   5S   +   5T   '   5V      P� 5W       �@9�ExpandDirection$ Right=�6A   . �5X   "   �� $ 
ExpandSite��6C    � ��$ Right=�6[   �� 5Y   "   $ 
HeaderSite��6C    � ��$
 Left=�6[   �� 5Z   "   $ 
HeaderSite��6:    � �� 5[   &   �� 5\   *   " d�60   .�5]   .   ��  � �� 5^   2   �� 5_   6   " d�6F   .R�5`   :   �� # z��6A   ._�5a   >   �  .   5b   B   �� 5c   F   $��* �6T   �� 5d   F   $��30 �6T   �� 5e   F   $��* �6T   .+�5g   B   � $��1��6G   
 5h   F   V� 5i   J   .~�5j   N   �� $ 90Q�6^   5k   K   .+�5m   F   A� $ circle��6N   
������ $��Center=�6q   $��19��6�   
���   �$��Center=�6�   $��19��6�   F� 5n   F   $ arrow��6K   "����@B `� � �D @KL � z `� 	$��Center=�6t    .  
�����_�$��2��6�   $��Center=�6�   
 5o   J   �� 5p   N   $ 0Q�6^   $	 0.5Q�6h   $	 0.5Q�6v   5r   G   5s   C   �� 5t   B   $��
Properties��6H   $��0��6]   
���   �$��18(�6}   
 5u   F   �� 5v   J   $	 -90Q�6Z   5x   C   �� 5y   B   $��History��6H   $��2��6Z   $	��Top=�6g   
���   �$��18(�6�   
 5z   F   �� 5{   J   $	 -90Q�6Z   5}   C   �� 5~   B   #��z��6S   #��z��6�   #  z 6�   $��Center=�6�   $��0,4,0,0q�6  $��1��6  ��.  . $	��Top=�6X  5   ?   5�   ;    5�   :   P� 5�   >    �@d�	IsChecked$
 TrueY�6[    5�   B   �� 5�   F   .��5�   J   �� $@ :(FrameworkElement.LayoutTransform).(RotateTransform.Angle)�6U   $ arrow��6�   .��5�   N   W� $
 -180X�6^   $ 0:0:0.5D�6h   5�   K   5�   G    5�   B   �� 5�   F   .��5�   J   �� $@ :(FrameworkElement.LayoutTransform).(RotateTransform.Angle)�6U   $ arrow��6�   .��5�   N   W� $ 0X�6^   $ 0:0:0.5D�6e   5�   K   5�   G   5�   ?   P� 5�   >    �@J�IsMouseOver . . �5�   B   �� $ circle��6[    � ��
 ��  �6o   �� 5�   B   $ circle��6Y    � ��
 ��  �6m   �� 5�   B   $ arrow��6[    � ��
 �����6n   5�   ?   5�   7   5�   /   5�   +   5�   #   5�      5�      5�      5�      �� 5�   
   " 9�6&   .�5�      ��  � ��
 �   �6+   �� 5�       � ��
 ���� 6+   �� 5�       � ��$ Stretch=�6;   �� 5�       � ��$ Stretch=�69   �� 5�       � ��
 �   �6,   �� 5�       � ��$ 2q�60   �� 5�       � ��$ 	0,10,10,0q�6'   �� 5�       � ��$ 
2, 3, 2, 3q�6(   6=   �� 5�       � ��$	 200��6&   64   �� 5�       � �� 5�      �� 5�      " 9�6&   .R�5�      �� #��z��6!   #��z��6M   #��z��6�    . ._�5�      ]� .+�5�   "   d� $ 
HeaderSite��6j   $��14(�6/   $��Black"�6=   $��Trebuchet MS)�6P   #��z��6~   #��z��6�   $	��Top=�6�   #��z��6�   #��z��6  $��1q�6�  $��0��6�  $��0��6�  #��z��6�  #��z��6   6]  �� *
IsExpanded+$ TwoWay=� �� *TemplatedParent+! 5�   &   �� 5�   *   .�5�   .   ��  � �� 5�   2   �� 5�   6   .R�5�   :   �� ._�5�   >   �� $��0q�6H    . 
���   �$��1��6}   $	" 1 2R�6�   5�   ;   5�   7   5�   /   5�   +   ��5�   &   �� 5�   *   " d�60   5�   #   �� 5�   "   $	 
ExpandSite��63   #��z��6G   #��z��6{   #  z 6�   $��Bottom=�6�   |�.  #��z��6  #��z��6H  $y�Visible=�6k  #��z��6�  $
��Auto��6�  
 5�   &   �� 5�   *   $# 0Q�69   5�   #   5�      5�       5�      P� 5�       �@9�
IsExpanded .  5�   "   �� 5�   &   .��5�   *   �� $ 
ExpandSite��65   $@ :(FrameworkElement.LayoutTransform).(ScaleTransform.ScaleY)�6X   .��5�   .   W� $ 1X�6>   $ 0:0:0.4D�6E   $	 0.5Q�6Y   5�   +   5�   '    5�   "   �� 5�   &   .��5�   *   �� $ 
ExpandSite��65   $@ :(FrameworkElement.LayoutTransform).(ScaleTransform.ScaleY)�6X   .��5�   .   W� $ 0X�6>   $ 0:0:0.4D�6E   $	 0.5Q�6Y   5�   +   5�   '   5�      P� 5�       �@9�ExpandDirection$
 Down=�6A   . �5�   "   �� $ 
ExpandSite��6C    � ��$ Bottom=�6[   �� 5�   "   $ 
HeaderSite��6C    � ��$	 Top=�6[   �� 5�   "   $ 
HeaderSite��6:    � �� 5�   &   �� 5�   *   " d�60   .�5�   .   ��  � �� 5�   2   �� 5�   6   " d�6F   .R�5�   :   �� # z��6A   ._�5�   >   � 
������  .  $ 5�   B   �� 5�   F   $��* �6W   �� 5�   F   $��30 �6W   .+�5�   B   � $��1��6G   
 5�   F   V� 5�   J   .~�5�   N   �� $ 0Q�6^   5�   K   .+�5�   F   A� $ circle��6N   
������ $��Center=�6q   $��19��6�   
���   �$��Center=�6�   $��19��6�   F� 5�   F   $ arrow��6K   "����@B `� � �D @KL � z `� 	$��Center=�6t    .  
�����_�$��2��6�   $��Center=�6�   
 5�   J   �� 5�   N   $ 0Q�6^   $	 0.5Q�6h   $	 0.5Q�6v   5�   G   5�   C   �� 5�   B   #��z��6S   #��z��6�   #  z 6�   $��Center=�6�   $��0,4,0,0q�6  $��1��6  ��.  . $	��Top=�6X  5�   ?   5�   ;    5�   :   P� 5�   >    �@d�	IsChecked$
 TrueY�6[    5�   B   �� 5�   F   .��5   J   �� $@ :(FrameworkElement.LayoutTransform).(RotateTransform.Angle)�6U   $ arrow��6�   .��5  N   W� $
 -180X�6^   $ 0:0:0.5D�6h   5  K   5  G    5  B   �� 5  F   .��5  J   �� $@ :(FrameworkElement.LayoutTransform).(RotateTransform.Angle)�6U   $ arrow��6�   .��5  N   W� $ 0X�6^   $ 0:0:0.5D�6e   5	  K   5
  G   5  ?   P� 5  >    �@J�IsMouseOver . . �5  B   �� $ circle��6[    � ��
 ��  �6o   �� 5  B   $ circle��6Y    � ��
 ��  �6m   �� 5  B   $ arrow��6[    � ��
 �����6n   5  ?   5  7   5  /   5  +   5  #   5     5     5     % 5     ���� 5     '��       " ��6   .�5      ��  � ��$	 100��6.   6<   �� 5!      � ��$ 0, 10, 0, 5q�6/   6E   5"     5#     5$     5&     5'     