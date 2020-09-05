using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InfoMeasures : MonoBehaviour
{
    #region Attributes
    private string[] infoTexte = new string[] { "Viele Infektionen werden über die Hände übertragen. Auch beim Coronavirus ist eine Übertragung durch Schmierinfektion über die Hände möglich, da mit den Händen oft unbewusst das Gesicht berührt wird und die Erreger so mit Schleimhäuten oder Bindehaut in Kontakt gebracht werden können. Deshalb ist es von Nutzen sich oft und gründlich die Hände zu waschen.Verbreite diese Information unter der Bevölkerung und fordere die Menschen dazu auf, in dieser Zeit besonderen Wert auf die Handhygiene zu legen.", "Da Untersuchungen ergeben haben, dass die ersten Krankheitszeichen erst bis zu zwei Wochen nach der eigentlichen Infektion erscheinen können, besteht die Gefahr in diesem Zeitraum unbewusst weitere Personen anzustecken. Daher ist es sinnvoll in öffentlichen Bereichen, in denen man auf andere Menschen trifft, eine Mund-Nasen-Bedeckung zu tragen, um eine Übertragung durch beim sprechen, husten und niesen ausgestoßene Tröpfchen zu verhindern. Beim Tragen einer Maske bzw. Mund-Nasen-Bedeckung geht es nicht vorrangig um den Selbstschutz, sondern darum seine Mitmenschen zu schützen. Verordne eine Mundschutzpflicht in öffentlichen Räumen, in denen sich mehrere Menschen längere Zeit aufhalten oder der Mindestabstand nicht immer eingehalten werden kann, wie Arbeitsplätze oder Geschäfte.", "Ein großes Problem des neuartigen Virus ist die Geschwindigkeit mit der er sich verbreitet. Ungehindert steigen die Fallzahlen der Infizierten exponentiell an. Infektionsketten sind nicht mehr nachvollziehbar und können somit nicht gestoppt werden. Eine Beschränkung mit wie vielen Leuten man in Kontakt tritt, verlangsamt nicht nur die Geschwindigkeit in der sich der Virus ausbreitet, da eine infizierte Person weniger weitere Personen ansteckt, sondern hilft auch dabei Infektionsketten wieder erkennen und stoppen zu können. Rufe zu Social Distancing auf und beschränke die zulässigen Kontaktpersonen.", "Wenn die Ausbreitung des Virus bereits in vollem Gange ist, Infektionsketten längst nicht mehr nachvollziehbar sind und das Gesundheitssystem droht überlastet zu werden, hilft nur noch eine weitreichende Quarantäne um die Verbreitung des Virus zu verlangsamen und weitere Infektionen zu stoppen. Fordere die Bevölkerung dazu auf Zuhause zu bleiben und erhalte nur die kritische Infrastruktur wie Grundversorgung und Apotheken am laufen um die weitere Verbreitung weitestgehend einzuschränken." , "Homeoffice ist eine gute Möglichkeit um Kontaktpersonen und mögliche Infektionen zu verringern. Am Arbeitsplatz sind oft mehrere Menschen über einen langen Zeitraum in den selben Räumlichkeiten und Mindestabstände können nicht immer eingehalten werden. Das Arbeiten von Zuhause ist bei allen bei denen dies möglich ist, eine gute Maßnahme um die Ausbreitung zu verlangsamen. Rufe die Unternehmen dazu auf, so viele ihrer Mitarbeiter ins Homeoffice zu schicken wie möglich und ggf.neue Homeoffice Potentiale zu nutzen." , "Bildungseinrichtungen bieten mit vielen Menschen in den selben Räumlichkeiten ein hohes Infektionspotential und tragen somit zur schnellen Verbreitung des Virus bei. Schließe vorübergehend Bildungseinrichtungen und mindere so die Anzahl an in Kontakt stehenden Personen und potentielle Infektionen.", "Zwar sind Kinder nicht sehr stark vom Virus betroffen, da die Krankheit meist sehr milde verläuft, allerdings können sie den Virus übertragen und somit weiter verbreiten. Mit der Schließung der Kitas und Kindergärten werden also nicht nur die Kinder und Angestellten geschützt, sondern auch gefährdetere Altersgruppen, indem die Verbreitung eingeschränkt wird.", "In lokalen Geschäften begegnen sich täglich viele fremde Menschen, die sonst nicht in Kontakt stehen würden und in den geschlossenen Räumen kommt es oft zu engerem Kontakt. Mit der Schließung von Geschäften wird zwar die Wirtschaft belastet, aber ein hohes Risiko vieler weiterer Infektionen beseitigt.", "Mit der Schließung der Grenzen kann das Risiko von Einreisenden, die sich mit dem Virus infiziert haben, beseitigt werden. Die Anzahl von Neuinfektionen kann verringert werden und im Kampf gegen die Ausbreitung kann fortan auf das eigene Land fokussiert werden.", "Beim Transport von Gütern interagieren viele Menschen miteinander und es ist nicht ausgeschlossen, dass dadurch Viren über weite Strecken verteilt werden. Schließe nicht notwendige Transportwege und Güterannahmestellen wie Flughäfen und Häfen um dieses Risiko zu vermeiden." };
    public GameObject infoPanel;
    private Text infoText;

    #endregion Attributes

    #region UnityMethods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        infoPanel.SetActive(false);
    }
    #endregion Unity Methods

    #region Methods

    public void setText(int i)
    {
        infoPanel.SetActive(true);
        infoText.text = infoTexte[i];
    }

    public void closePanel()
    {
        infoPanel.SetActive(false);
    }

    #endregion Methods
}
