   M S B A M L   `   `   `  ����  SQL    
SQL.detail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency .  � Title$ 
MainWindow��5   	   $	��500��6   $	��640��6)   ��5      Z�  � 	Resources 5         ButtonStyle2 �� 
TargetType �� Property �� Value �� 
TargetType �Name	 J� RenderTransformOrigin'  !System.Windows.VisualStateManager
   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value A�Name J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   
BlurRadius   Opacity J� SnapsToDevicePixels �� Triggers P� Property P� Value��%g  &	        �� 5   
   " ��6%   .�5      ��  � �� 5	      �� 5
      " ��6&   .R�5      � $
 grid��6   $	 0.5,0.5&�6-   z�5      V� 5   "   .~�5   &   �� �� 5   &   �� 5   &   T� 5   &   5   #   
 5        5   "   CommonStates��. 5   &     
Normal��62     5   &   	MouseOver��62     5   &   Pressed��. 5   *   �� .��5   .   U� $3 -(UIElement.Effect).(DropShadowEffect.Opacity)�6L   $ ellipse��6�   .\�5   2     $ 0��6G   $ 0Q�6S   5   /   U� 5   .   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6L   $
 grid��6�   .\�5   2     $ 0��6G   $ 1Q�6S   5   /   U� 5    .   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6L   $
 grid��6�   .\�5!   2     $ 0��6G   $ 1Q�6S   5"   /   5#   +   5$   '     5%   &   Disabled��62   5&   #   .+�5(      A� $ ellipse��6&   #��z��67    5)   "     5*   &   $ 1Q�67   $ 1Q�6G   $ 0.215Q�6V   5,      �� 5-      #��z��6/   ��. # z 6�   #��z��6�   5.       5/      P� 50       �@J�	IsFocused . 6;   P� 51       �@��IsDefaulted . 6=   P� 52       �@J�IsMouseOver . 6=   P� 53       � �� . 6;   P� 54       � {� .  6;   56      58      59      5:      .��5;      � .+�5<   
   �� -   5         ��Name$ 
background��5<      ���	#FFF1C96A �� RadiusX$ 10��69    �� RadiusY$ 10��6F    5=        5>      $
 0.45Q�6#   $ 3Q�62   5@      �� 5A   
   ���	#FF45B29D$
��Left=�6%   $	��423��6@   $��	40,40,0,0q�6M   $ 10��6`   $ 10��6m   $	��Top=�6z   $	��555��6�    5B        5C      $ 3Q�6#   $
 0.45Q�63   5E      �� 5F   
   -   5         ��Name$ Introduction��5F      $
��Left=�6*   $��	40,54,0,0q�6E   $
��Wrap=�6X   $	��Top=�6l   $	��395��6�   $	��555��6�   $��Arial)�6�   $��14(�6�   �� 5G   
   -   5         ��Name$ 
ButtonExit��5G      $��X��6%   $��Right=�61   $��30��6M   $��0,9.997,20.6,0q�6Y   #���   6q   $	��Top=�6�   $��30��6�   
����������	#FFDE7721 �� IsCancel . 6�   5H      5I      