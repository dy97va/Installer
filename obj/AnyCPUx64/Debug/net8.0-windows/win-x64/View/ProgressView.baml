   M S B A M L   `   `   `  ����D  @Installer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Installer.ViewInstaller.View  5      !    Installer.View.ProgressView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Installer.View     5        � 	Resources  5
         ProgressBarStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� RadiusX �� RadiusY  ButtonStyle��%�  &	        &	 <    �� 5   
   " �6)   .�5      ��  � �� 5      �� 5      " �6&   .R�5      � .+�5      �� #��z��6%   #��z��5   %   $��1q�5   %   $ 5��5   %   ._�5   "   � $
}�True��6'   .+�5   &   �� $ 
PART_Track��60   #��z��5   0   $ 5��5   0   $ 5��6<   �� 5   &   $ PART_Indicator��60   #��z��5   0   $ 5��5   0   $ 5��6<   $
��Left=�5   0   5   #   5      5      5      5!      �� 5"       � ��
 �����6+   �� 5#       � ��
 ����6+   �� 5$       � ��$ 10��6'   5%      �� 5&   
   " ��6$   .�5'      ��  � �� 5(      �� 5)      " ��6&   .R�5*      �� #��z��6!   #��z��5+      #��z��5,      $ 15��5-      ._�5/      �� $��Center=�60   $��Center=�6K   50      51      53      �� 54       � �� �	#FF6549E96+   �� 55       � ��
 �����6+   �� 56       � ��$
 Bold"�6+   �� 57       �@�Cursor$
 Hand��6'   58      59      .��5;      � .+�5<   
   �� -   5        $��ProgressText��5<      
�������$��Installation Progress��6;   $	��Top=�6X   $��Center=�6p   $��0,20,0,0q�6�   $��40(�6�   � 5=   
   -   5        $��ProgressBar��5=      $	��600��6)   $��10��65   $��Center=�6A   $��Center=�6\   $��0,0,0,0q�6y   #��[  6�   �� 5>   
   -   5        	 ��Name$	 
DoneButton��5>      $
��Done��6%   $	��100��64   $��30��6@   $��0,0,0,30q�6L   $��Bottom=�6^   $��Center=�6y   $y�Hidden=�6�   #��[ 6�   5?      5@      