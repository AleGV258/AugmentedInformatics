using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarIdXTarget : MonoBehaviour
{
    public GameObject GOCambioPantallas;

    [System.Serializable]
    public struct TargetStruct { 
        public string nombre; 
        public int id;  
        
        public TargetStruct(string nombre, int id) {
            this.nombre = nombre;
            this.id = id;
        }
    }

    public TargetStruct[] targets;

    void Start()
    {
        targets = new TargetStruct[115];
        targets[0] = new TargetStruct("CD",1);
        targets[1] = new TargetStruct("LaCER",2);
        targets[2] = new TargetStruct("LE", 3);
        targets[3] = new TargetStruct("NUTRI", 4);
        targets[4] = new TargetStruct("MED", 5);
        targets[5] = new TargetStruct("PSIC", 6);
        targets[6] = new TargetStruct("FISIO", 7);
        targets[7] = new TargetStruct("OLIMPO", 8);
        targets[8] = new TargetStruct("SPACERTZ", 9);
        targets[9] = new TargetStruct("POSGRADO", 10);
        targets[10] = new TargetStruct("EMPRENDIMIENTO", 11);
        targets[11] = new TargetStruct("CAPACITACION", 12);
        targets[12] = new TargetStruct("DEPORTES", 13);
        targets[13] = new TargetStruct("L-INC", 14);
        targets[14] = new TargetStruct("L-INF", 15);
        targets[15] = new TargetStruct("L-LAT", 16);
        targets[16] = new TargetStruct("L-TEL", 17);
        targets[17] = new TargetStruct("L-SOF", 18);
        targets[18] = new TargetStruct("LR2", 19);
        targets[19] = new TargetStruct("LR1", 20);
        targets[20] = new TargetStruct("INN09", 21);
        targets[21] = new TargetStruct("INN08", 22);
        targets[22] = new TargetStruct("INN07", 23);
        targets[23] = new TargetStruct("INN06", 24);
        targets[24] = new TargetStruct("INN05", 25);
        targets[25] = new TargetStruct("INN04", 26);
        targets[26] = new TargetStruct("INN03", 27);
        targets[27] = new TargetStruct("INN02", 28);
        targets[28] = new TargetStruct("INN01", 29);
        targets[29] = new TargetStruct("D10", 30);
        targets[30] = new TargetStruct("D09", 31);
        targets[31] = new TargetStruct("D08", 32);
        targets[32] = new TargetStruct("D07", 33);
        targets[33] = new TargetStruct("D06", 34);
        targets[34] = new TargetStruct("D05", 35);
        targets[35] = new TargetStruct("D04", 36);
        targets[36] = new TargetStruct("D03", 37);

        targets[37] = new TargetStruct("D02", 38);
        targets[38] = new TargetStruct("D01", 39);
        targets[39] = new TargetStruct("C45", 40);
        targets[40] = new TargetStruct("C44", 41);
        targets[41] = new TargetStruct("C43", 42);
        targets[42] = new TargetStruct("C42", 43);
        targets[43] = new TargetStruct("C41", 44);
        targets[44] = new TargetStruct("C40", 45);
        targets[45] = new TargetStruct("C39", 46);
        targets[46] = new TargetStruct("C38", 47);
        targets[47] = new TargetStruct("C37", 48);
        targets[48] = new TargetStruct("C36", 49);
        targets[49] = new TargetStruct("C35", 50);
        targets[50] = new TargetStruct("C34", 51);
        targets[51] = new TargetStruct("C33", 52);
        targets[52] = new TargetStruct("C32", 53);
        targets[53] = new TargetStruct("C31", 54);
        targets[54] = new TargetStruct("C30", 55);
        targets[55] = new TargetStruct("C29", 56);
        targets[56] = new TargetStruct("C28", 57);
        targets[57] = new TargetStruct("C27", 58);
        targets[58] = new TargetStruct("C26", 59);
        targets[59] = new TargetStruct("C25", 60);
        targets[60] = new TargetStruct("C24", 61);
        targets[61] = new TargetStruct("C23", 62);
        targets[62] = new TargetStruct("C22", 63);
        targets[63] = new TargetStruct("C21", 64);
        targets[64] = new TargetStruct("C20", 65);
        targets[65] = new TargetStruct("C19", 66);
        targets[66] = new TargetStruct("C18", 67);
        targets[67] = new TargetStruct("C17", 68);
        targets[68] = new TargetStruct("C16", 69);

        targets[69] = new TargetStruct("C15", 70);
        targets[70] = new TargetStruct("C14", 71);
        targets[71] = new TargetStruct("C13", 72);
        targets[72] = new TargetStruct("C12", 73);
        targets[73] = new TargetStruct("C11", 74);
        targets[74] = new TargetStruct("C10", 75);
        targets[75] = new TargetStruct("C09", 76);
        targets[76] = new TargetStruct("C08", 77);
        targets[77] = new TargetStruct("C07", 78);
        targets[78] = new TargetStruct("C06", 79);
        targets[79] = new TargetStruct("C05", 80);
        targets[80] = new TargetStruct("C04", 81);
        targets[81] = new TargetStruct("C03", 82);
        targets[82] = new TargetStruct("C02", 83);
        targets[83] = new TargetStruct("C01", 84);
        targets[84] = new TargetStruct("B03", 85);
        targets[85] = new TargetStruct("B02", 86);
        targets[86] = new TargetStruct("B01", 87);
        targets[87] = new TargetStruct("A26", 88);
        targets[88] = new TargetStruct("A25", 89);
        targets[89] = new TargetStruct("A24", 90);
        targets[90] = new TargetStruct("A23", 91);
        targets[91] = new TargetStruct("A22", 92);
        targets[92] = new TargetStruct("A21", 93);
        targets[93] = new TargetStruct("A20", 94);
        targets[94] = new TargetStruct("A19", 95);
        targets[95] = new TargetStruct("A18", 96);
        targets[96] = new TargetStruct("A17", 97);
        targets[97] = new TargetStruct("A16", 98);
        targets[98] = new TargetStruct("A15", 99);
        targets[99] = new TargetStruct("A14", 100);
        targets[100] = new TargetStruct("A13", 101);
        targets[101] = new TargetStruct("A12", 102);
        targets[102] = new TargetStruct("A11", 103);
        targets[103] = new TargetStruct("A10", 104);
        targets[104] = new TargetStruct("A09", 105);
        targets[105] = new TargetStruct("A08", 106);
        targets[106] = new TargetStruct("A07", 107);
        targets[107] = new TargetStruct("A06", 108);
        targets[108] = new TargetStruct("A05", 109);
        targets[109] = new TargetStruct("A04-B", 110);
        targets[110] = new TargetStruct("A04-A", 111);
        targets[111] = new TargetStruct("A03-B", 112);
        targets[112] = new TargetStruct("A03-A", 113);
        targets[113] = new TargetStruct("A02", 114);
        targets[114] = new TargetStruct("A01", 115);

        for (int i = 0; i <targets.Length; i++) {
            GameObject target = transform.Find("AR_ImageTarget_" + targets[i].nombre).gameObject;
            // Debug.Log(targets[i].nombre);
            TargetId targetIdScript = target.GetComponent<TargetId>();
            targetIdScript.idTargetSalon =  targets[i].id;
            targetIdScript.Target = target;
            targetIdScript.cambioPantallas = GOCambioPantallas;
        }
    }
    void Update(){}
}
