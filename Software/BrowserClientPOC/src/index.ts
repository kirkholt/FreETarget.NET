import { AirRifle } from "./targets/AirRifle";
import { Rifle50m } from "./targets/Rifle50m";
import { SvgImage } from "./svg/svgImage";


function init() {
  // const svgButton = document.querySelector('button.createSvg'); // select the button element
  
  // svgButton.addEventListener('click', createATarget);
  // createATarget();
  
  // svgButton.addEventListener('click', createSvg);
 //createSvg();

 let airRifle : AirRifle = new AirRifle(4.5)
 let svg = airRifle.paintTarget();
 document.querySelector('div.svg.airRifle').innerHTML = svg;

 let rifle50m : Rifle50m = new Rifle50m(5.6)
 svg = rifle50m.paintTarget();
 document.querySelector('div.svg.rifle50m').innerHTML = svg;

}

function createSvg(e?: Event) {
  if (e) {
  e.preventDefault();
}

  let width = 2000;
  let center = width / 2;


  let baggrund = "#FFE4B5";
  let sort = "black";
  let svgImage = new SvgImage(width, width);
  svgImage.textFont = "Arial";
  svgImage.addRectangle(0, 0, width, width, baggrund);
  svgImage.addText(40, 40, "Modeltype: M90", 30, sort);
  svgImage.addText(40, 80, "Rifle target 50m, cal 5.6mm", 30, sort);

  svgImage.addCircle(center, center, 857, baggrund, sort, 1); // 4
  svgImage.addCircle(center, center, 732, sort); //5
  svgImage.addCircle(center, center, 607, sort, baggrund, 1); // 6
  svgImage.addCircle(center, center, 482, sort, baggrund, 1); // 7
  svgImage.addCircle(center, center, 357, sort, baggrund, 1); // 8
  svgImage.addCircle(center, center, 232, sort, baggrund, 1); // 9
  svgImage.addCircle(center, center, 107, sort, baggrund, 1); // 10
  svgImage.addCircle(center, center, 44, sort, baggrund, 1); // X

  
  
  [30,150, 270].forEach(function(deg) {
    let ang = 2 * Math.PI * deg / 360;
    //svgImage.addLine(center, center, center + 1000 * Math.cos(ang) , center - 1000 * Math.sin(ang),"red", "red", 1);

    svgImage.addText(center + 170 * Math.cos(ang) -12, center - 170 * Math.sin(ang) + 19, "9", 50, baggrund);
    svgImage.addText(center + 290 * Math.cos(ang) -12, center - 290 * Math.sin(ang) + 19, "8", 50, baggrund);
    svgImage.addText(center + 420 * Math.cos(ang) -12, center - 420 * Math.sin(ang) + 19, "7", 50, baggrund);
    svgImage.addText(center + 540 * Math.cos(ang) -12, center - 540 * Math.sin(ang) + 19, "6", 50, baggrund);
    svgImage.addText(center + 670 * Math.cos(ang) -12, center - 670 * Math.sin(ang) + 19, "5", 50, baggrund);
  });

  let svgString = svgImage.toString();
  document.querySelector('div.svg').innerHTML = svgString;
}

init();