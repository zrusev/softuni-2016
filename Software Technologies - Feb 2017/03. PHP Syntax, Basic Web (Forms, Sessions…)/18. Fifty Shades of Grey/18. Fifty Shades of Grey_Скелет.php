<?php
$rowColor = 0;
for ($row = 0; $row < 5; $row++)
{
    $colColor1 = $rowColor;
    for ($col = 0; $col < 10; $col++)
    {
        /*$colColor2 = $colColor1 + 5;
        $colColor3 = $colCo lor2 + 5;*/
        echo "<div style=\"background-color: rgb($colColor1, $colColor1, $colColor1);\"></div>";
        $colColor1 += 5;
    }
    echo "<br>";
    $rowColor += 51;
}
?>
