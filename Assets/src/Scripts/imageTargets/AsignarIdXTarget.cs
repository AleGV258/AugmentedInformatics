using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarIdXTarget : MonoBehaviour
{
    public GameObject GOCambioPantallas; // GameObject del script cambio pantallas

    // Agreaga la estructura a Unity Inspector, lo que le permite establecer los valores de estos campos en el editor de Unity
    [System.Serializable]
    public struct TargetStruct { // Estructura de un ImageTarget
        // Se declaran las variables que se deben de asignar a los ImageTargets al momento de iniciar la ejecución del programa
        public string nombre; // Nombre del target
        public int id; // Id del target
        
        // Función para establecer los valores a cada ImageTarget segun los parámetros recibidos
        public TargetStruct(string nombre, int id) {
            this.nombre = nombre; // Se asigna el nombre del target
            this.id = id; // Se asigna el id del target
        }
    }

    public TargetStruct[] targets; // Arreglo de los ImageTargets donde se establecen sus nombre e id

    // Función que se ejecuta al iniciar la aplicación y en su primer frame
    void Start()
    {
        targets = new TargetStruct[115]; // Se asigna un tamaño especfíco de targets que van a contener el arreglo
        targets[0] = new TargetStruct("CD", 1); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[1] = new TargetStruct("LaCER", 2); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[2] = new TargetStruct("LE", 3); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[3] = new TargetStruct("NUTRI", 4); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[4] = new TargetStruct("MED", 5); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[5] = new TargetStruct("PSIC", 6); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[6] = new TargetStruct("FISIO", 7); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[7] = new TargetStruct("OLIMPO", 8); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[8] = new TargetStruct("SPACERTZ", 9); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[9] = new TargetStruct("POSGRADO", 10); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[10] = new TargetStruct("EMPRENDIMIENTO", 11); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[11] = new TargetStruct("CAPACITACION", 12); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[12] = new TargetStruct("DEPORTES", 13); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[13] = new TargetStruct("L-INC", 14); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[14] = new TargetStruct("L-INF", 15); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[15] = new TargetStruct("L-LAT", 16); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[16] = new TargetStruct("L-TEL", 17); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[17] = new TargetStruct("L-SOF", 18); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[18] = new TargetStruct("LR2", 19); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[19] = new TargetStruct("LR1", 20); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[20] = new TargetStruct("INN09", 21); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[21] = new TargetStruct("INN08", 22); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[22] = new TargetStruct("INN07", 23); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[23] = new TargetStruct("INN06", 24); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[24] = new TargetStruct("INN05", 25); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[25] = new TargetStruct("INN04", 26); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[26] = new TargetStruct("INN03", 27); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[27] = new TargetStruct("INN02", 28); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[28] = new TargetStruct("INN01", 29); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[29] = new TargetStruct("D10", 30); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[30] = new TargetStruct("D09", 31); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[31] = new TargetStruct("D08", 32); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[32] = new TargetStruct("D07", 33); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[33] = new TargetStruct("D06", 34); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[34] = new TargetStruct("D05", 35); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[35] = new TargetStruct("D04", 36); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[36] = new TargetStruct("D03", 37); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[37] = new TargetStruct("D02", 38); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[38] = new TargetStruct("D01", 39); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[39] = new TargetStruct("C45", 40); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[40] = new TargetStruct("C44", 41); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[41] = new TargetStruct("C43", 42); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[42] = new TargetStruct("C42", 43); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[43] = new TargetStruct("C41", 44); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[44] = new TargetStruct("C40", 45); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[45] = new TargetStruct("C39", 46); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[46] = new TargetStruct("C38", 47); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[47] = new TargetStruct("C37", 48); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[48] = new TargetStruct("C36", 49); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[49] = new TargetStruct("C35", 50); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[50] = new TargetStruct("C34", 51); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[51] = new TargetStruct("C33", 52); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[52] = new TargetStruct("C32", 53); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[53] = new TargetStruct("C31", 54); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[54] = new TargetStruct("C30", 55); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[55] = new TargetStruct("C29", 56); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[56] = new TargetStruct("C28", 57); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[57] = new TargetStruct("C27", 58); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[58] = new TargetStruct("C26", 59); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[59] = new TargetStruct("C25", 60); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[60] = new TargetStruct("C24", 61); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[61] = new TargetStruct("C23", 62); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[62] = new TargetStruct("C22", 63); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[63] = new TargetStruct("C21", 64); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[64] = new TargetStruct("C20", 65); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[65] = new TargetStruct("C19", 66); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[66] = new TargetStruct("C18", 67); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[67] = new TargetStruct("C17", 68); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[68] = new TargetStruct("C16", 69); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[69] = new TargetStruct("C15", 70); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[70] = new TargetStruct("C14", 71); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[71] = new TargetStruct("C13", 72); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[72] = new TargetStruct("C12", 73); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[73] = new TargetStruct("C11", 74); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[74] = new TargetStruct("C10", 75); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[75] = new TargetStruct("C09", 76); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[76] = new TargetStruct("C08", 77); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[77] = new TargetStruct("C07", 78); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[78] = new TargetStruct("C06", 79); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[79] = new TargetStruct("C05", 80); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[80] = new TargetStruct("C04", 81); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[81] = new TargetStruct("C03", 82); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[82] = new TargetStruct("C02", 83); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[83] = new TargetStruct("C01", 84); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[84] = new TargetStruct("B03", 85); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[85] = new TargetStruct("B02", 86); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[86] = new TargetStruct("B01", 87); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[87] = new TargetStruct("A26", 88); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[88] = new TargetStruct("A25", 89); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[89] = new TargetStruct("A24", 90); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[90] = new TargetStruct("A23", 91); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[91] = new TargetStruct("A22", 92); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[92] = new TargetStruct("A21", 93); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[93] = new TargetStruct("A20", 94); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[94] = new TargetStruct("A19", 95); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[95] = new TargetStruct("A18", 96); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[96] = new TargetStruct("A17", 97); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[97] = new TargetStruct("A16", 98); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[98] = new TargetStruct("A15", 99); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[99] = new TargetStruct("A14", 100); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[100] = new TargetStruct("A13", 101); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[101] = new TargetStruct("A12", 102); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[102] = new TargetStruct("A11", 103); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[103] = new TargetStruct("A10", 104); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[104] = new TargetStruct("A09", 105); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[105] = new TargetStruct("A08", 106); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[106] = new TargetStruct("A07", 107); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[107] = new TargetStruct("A06", 108); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[108] = new TargetStruct("A05", 109); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[109] = new TargetStruct("A04-B", 110); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[110] = new TargetStruct("A04-A", 111); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[111] = new TargetStruct("A03-B", 112); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[112] = new TargetStruct("A03-A", 113); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[113] = new TargetStruct("A02", 114); // Se asigna el nombre del target, su id, en una posición específica del arreglo
        targets[114] = new TargetStruct("A01", 115); // Se asigna el nombre del target, su id, en una posición específica del arreglo

        // Ciclo que itera sobre todo el arreglo de targets para asignar sus valores en otros scripts
        for (int i = 0; i <targets.Length; i++) {
            GameObject target = transform.Find("AR_ImageTarget_" + targets[i].nombre).gameObject; // Se declara un GameObject donde se va a buscar y asignar un target en específico, según su nombre
            // Debug.Log(targets[i].nombre);
            TargetId targetIdScript = target.GetComponent<TargetId>(); // Se busca el script de target id
            targetIdScript.idTargetSalon =  targets[i].id; // Se asigna el id en el script target id
            targetIdScript.Target = target; // Se asigna el target en el script target id
            targetIdScript.cambioPantallas = GOCambioPantallas; // Se asigna el script de cambio pantallas en el script target id
        }
    }
}
