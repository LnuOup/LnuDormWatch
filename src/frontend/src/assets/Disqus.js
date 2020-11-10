function disqus(pageIdentifier) {

  var disqus_config = function () {
    this.page.url = document.head.querySelector("link[rel='canonical']").href; // Here page's canonical URL variable given
    this.page.identifier = pageIdentifier; // Here page's unique identifier variable given
  };

  (function () { // DON'T EDIT BELOW THIS LINE
    var d = document, s = d.createElement('script');
    s.src = 'https://lnudormwatch.disqus.com/embed.js';
    s.setAttribute('data-timestamp', +new Date());
    (d.head || d.body).appendChild(s);
  })();
}
